using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.Interfaces;
using Mtf.Maui.Controls.Messages;

namespace M.A.G.U.S.Assistant.Platforms.iOS;

internal class ShakeService : IShakeService
{
    public const double ThresholdG = 2.2;
    public const int DebounceMs = 800;

    private double thresholdG = ThresholdG;
    private int debounceMs = DebounceMs;
    private DateTime lastShake = DateTime.MinValue;

    public bool IsMonitoring => Accelerometer.IsMonitoring;

    public event EventHandler? ShakeDetected;

    public void Start(double thresholdG = ThresholdG, int debounceMs = DebounceMs)
    {
        this.thresholdG = thresholdG;
        this.debounceMs = debounceMs;

        try
        {
            Accelerometer.ReadingChanged += OnAccelerometerReadingChanged;

            if (!IsMonitoring)
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

            if (IsMonitoring)
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
