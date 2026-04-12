using M.A.G.U.S.Assistant.Interfaces.Bluetooth;
using Windows.Networking.Sockets;

namespace M.A.G.U.S.Assistant.Platforms.Windows;

using global::Windows.Devices.Bluetooth.Rfcomm;
using global::Windows.Storage.Streams;
using System.Diagnostics;

internal partial class WindowsBluetoothListener : IBluetoothListener, IDisposable
{
    private StreamSocketListener? listener;
    private TaskCompletionSource<IBluetoothConnection>? pendingTcs;
    private readonly Lock acceptLock = new();
    private bool isBound;
    private RfcommServiceProvider? rfcommProvider;
    private static readonly Guid ServiceGuid = new(Constants.ServiceGuid);

    public async Task<IBluetoothConnection> AcceptConnectionAsync(CancellationToken ct)
    {
        bool needBind = false;

        lock (acceptLock)
        {
            if (listener == null)
            {
                listener = new StreamSocketListener();
                listener.ConnectionReceived += (sender, args) =>
                {
                    TaskCompletionSource<IBluetoothConnection>? toSet;
                    lock (acceptLock)
                    {
                        toSet = pendingTcs;
                        pendingTcs = null;
                    }
                    //toSet?.TrySetResult(new WindowsBluetoothConnection(args.Socket));
                    toSet?.TrySetResult(new WindowsBluetoothConnection(args.Socket, args.Socket.Information.RemoteAddress?.DisplayName ?? "Unknown"));
                };

                needBind = true;
            }

            if (pendingTcs != null)
            {
                throw new InvalidOperationException("Only one concurrent AcceptConnectionAsync call is supported by this listener.");
            }

            // Use RunContinuationsAsynchronously to avoid running continuations inline on the event thread
            pendingTcs = new TaskCompletionSource<IBluetoothConnection>(TaskCreationOptions.RunContinuationsAsynchronously);
        }

        if (needBind && !isBound)
        {
            // Create and advertise an RFCOMM service and bind the listener to the
            // RFCOMM service id. Binding to an arbitrary service name will fail
            // at the native/WinRT layer (COMException) - use RfcommServiceProvider.
            //var rfcommId = RfcommServiceId.FromUuid(RfcommServiceId.SerialPort.Uuid);
            
            var rfcommId = RfcommServiceId.FromUuid(ServiceGuid);
            rfcommProvider = await RfcommServiceProvider.CreateAsync(rfcommId).AsTask().ConfigureAwait(false);

            try
            {
                //await listener!.BindServiceNameAsync(rfcommId.AsString()).AsTask().ConfigureAwait(false);
                await listener!.BindServiceNameAsync(
                    rfcommId.AsString(),
                    SocketProtectionLevel.BluetoothEncryptionAllowNullAuthentication)
                    .AsTask()
                    .ConfigureAwait(false);

                // Add a simple service name SDP attribute so other devices can display a name
                try
                {
                    var writer = new DataWriter();
                    writer.WriteByte(0x25);
                    writer.WriteByte((byte)"MAGUS_Service".Length);
                    writer.WriteString("MAGUS_Service");
                    rfcommProvider.SdpRawAttributes.Add(0x100, writer.DetachBuffer());
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"SDP attribute warning: {ex}");
                }

                // Start advertising so remote devices can discover/connect
                try
                {
                    rfcommProvider.StartAdvertising(listener);
                }
                catch (System.Runtime.InteropServices.COMException ex)
                {
                    Debug.WriteLine($"StartAdvertising COMException: HResult=0x{ex.HResult:X8}, Message={ex.Message}");
                    throw;
                }

                isBound = true;
            }
            catch (System.Runtime.InteropServices.COMException comEx)
            {
                // Surface native HRESULT and message for diagnosis and rethrow so upper layer can log
                Debug.WriteLine($"BindServiceNameAsync COMException: HResult=0x{comEx.HResult:X8} Message={comEx.Message}");
                throw;
            }
        }

        using (ct.Register(() =>
        {
            TaskCompletionSource<IBluetoothConnection>? tcsToCancel;
            lock (acceptLock)
            {
                tcsToCancel = pendingTcs;
                pendingTcs = null;
            }
            tcsToCancel?.TrySetCanceled();
        }))
        {
            return await pendingTcs!.Task.ConfigureAwait(false);
        }
    }

    public void Dispose()
    {
        TaskCompletionSource<IBluetoothConnection>? tcsToCancel;
        lock (acceptLock)
        {
            tcsToCancel = pendingTcs;
            pendingTcs = null;
        }
        tcsToCancel?.TrySetCanceled();

        try { listener?.Dispose(); } catch { }
    }
}
