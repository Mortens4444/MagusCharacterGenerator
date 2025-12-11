using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.Interfaces;
using Mtf.Maui.Controls.Messages;

namespace M.A.G.U.S.Assistant.Platforms.Android;

internal class ShakeService : IShakeService
{
    private double thresholdG = 2.2;
    private int debounceMs = 800;
    private DateTime lastShake = DateTime.MinValue;

    public bool IsMonitoring => throw new NotImplementedException();

    public event EventHandler? ShakeDetected;

    public void Start(double thresholdG = 2.2, int debounceMs = 800)
    {
        try
        {
            Accelerometer.ReadingChanged += OnAccelerometerReadingChanged;
            if (!Accelerometer.IsMonitoring)
            {
                Accelerometer.Start(SensorSpeed.UI);
            }
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }
    }

    public void Stop()
    {
        try
        {
            Accelerometer.ReadingChanged -= OnAccelerometerReadingChanged;
            if (Accelerometer.IsMonitoring)
            {
                Accelerometer.Stop();
            }
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }
    }

    private void OnAccelerometerReadingChanged(object? sender, AccelerometerChangedEventArgs e)
    {
        try
        {
            var ax = e.Reading.Acceleration.X;
            var ay = e.Reading.Acceleration.Y;
            var az = e.Reading.Acceleration.Z;
            var total = Math.Sqrt(ax * ax + ay * ay + az * az);
            if (total > thresholdG)
            {
                var now = DateTime.UtcNow;
                if ((now - lastShake).TotalMilliseconds > debounceMs)
                {
                    lastShake = now;
                    ShakeDetected?.Invoke(this, EventArgs.Empty);
                }
            }
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }
    }

    public void Dispose() => Stop();
}
