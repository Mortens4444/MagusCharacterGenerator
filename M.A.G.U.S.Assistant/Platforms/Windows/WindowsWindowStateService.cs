using global::Windows.Graphics;
using M.A.G.U.S.Assistant.Interfaces;
#if WINDOWS
using Microsoft.Maui.Platform;
using Microsoft.UI.Windowing;
using MauiWindow = Microsoft.Maui.Controls.Window;
using NativeWindow = Microsoft.UI.Xaml.Window;

namespace M.A.G.U.S.Assistant.Platforms.Windows;

internal sealed partial class WindowsWindowStateService : IWindowStateService, IDisposable
{
    private const string XKey = "WindowX";
    private const string YKey = "WindowY";
    private const string WKey = "WindowWidth";
    private const string HKey = "WindowHeight";
    private const string StateKey = "WindowState";

    private AppWindow? appWindow;
    private NativeWindow? nativeWindow;
    private Timer? saveTimer;
    private readonly Lock lockObject = new();

    public void Attach(MauiWindow window)
    {
        nativeWindow = window?.Handler?.PlatformView as NativeWindow;
        appWindow = nativeWindow?.GetAppWindow();
        if (appWindow == null)
        {
            return;
        }

        appWindow.Changed += (sender, args) =>
        {
            System.Diagnostics.Debug.WriteLine($"AppWindow Changed: Position={args.DidPositionChange}, Size={args.DidSizeChange}, Presenter={args.DidPresenterChange}");
            ScheduleSave();
        };

        nativeWindow!.SizeChanged += (s, e) =>
        {
            System.Diagnostics.Debug.WriteLine($"SizeChanged: {e.Size.Width} x {e.Size.Height}");
            ScheduleSave();
        };

        nativeWindow.Closed += (s, e) =>
        {
            System.Diagnostics.Debug.WriteLine("Window closing, saving state...");
            SaveImmediate();
        };
    }

    private void ScheduleSave()
    {
        lock (lockObject)
        {
            saveTimer?.Dispose();
            saveTimer = new Timer(_ =>
            {
                SaveImmediate();
            }, null, 5000, Timeout.Infinite);
        }
    }

    private void SaveImmediate()
    {
        lock (lockObject)
        {
            try
            {
                if (appWindow?.Presenter is not OverlappedPresenter p)
                {
                    System.Diagnostics.Debug.WriteLine("❌ Presenter is null or not OverlappedPresenter");
                    return;
                }

                System.Diagnostics.Debug.WriteLine($"Current state: {p.State}");
                if (p.State == OverlappedPresenterState.Restored)
                {
                    var r = appWindow.Position;
                    var s = appWindow.Size;

                    Preferences.Set(XKey, r.X);
                    Preferences.Set(YKey, r.Y);
                    Preferences.Set(WKey, s.Width);
                    Preferences.Set(HKey, s.Height);

                    System.Diagnostics.Debug.WriteLine($"✓ SAVED: X={r.X}, Y={r.Y}, W={s.Width}, H={s.Height}");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"Skipping position/size save (state={p.State})");
                }

                Preferences.Set(StateKey, (int)p.State);
                System.Diagnostics.Debug.WriteLine($"✓ SAVED state: {p.State} ({(int)p.State})");

                // Ellenőrzés: tényleg mentődött?
                int savedX = Preferences.Get(XKey, -999);
                int savedY = Preferences.Get(YKey, -999);
                System.Diagnostics.Debug.WriteLine($"Verification: X={savedX}, Y={savedY}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ Save error: {ex.Message}");
            }
        }
    }

    public void Restore(MauiWindow window)
    {
        nativeWindow = window?.Handler?.PlatformView as NativeWindow;
        appWindow = nativeWindow?.GetAppWindow();
        
        if (appWindow == null)
        {
            return;
        }

        if (!Preferences.ContainsKey(WKey))
        {
            System.Diagnostics.Debug.WriteLine("No saved window state found, using defaults");
            return;
        }

        int x = Preferences.Get(XKey, 100);
        int y = Preferences.Get(YKey, 100);
        int w = Preferences.Get(WKey, 1200);
        int h = Preferences.Get(HKey, 800);

        System.Diagnostics.Debug.WriteLine($"✓ RESTORING: X={x}, Y={y}, W={w}, H={h}");

        var rect = new RectInt32(x, y, w, h);
        appWindow.MoveAndResize(rect);

        var state = (OverlappedPresenterState)Preferences.Get(StateKey, (int)OverlappedPresenterState.Restored);
        System.Diagnostics.Debug.WriteLine($"✓ RESTORING state: {state}");

        if (appWindow.Presenter is OverlappedPresenter p)
        {
            switch (state)
            {
                case OverlappedPresenterState.Maximized:
                    p.Maximize();
                    break;
                case OverlappedPresenterState.Minimized:
                    p.Minimize();
                    break;
                default:
                    p.Restore();
                    break;
            }
        }
    }

    public void Dispose()
    {
        appWindow?.Destroy();
        appWindow = null;

        nativeWindow?.Close();
        nativeWindow = null;

        saveTimer?.Dispose();
        saveTimer = null;
    }
}
#endif