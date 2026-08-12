namespace MAGUS.Assistant.Interfaces;

internal interface IShakeService : IDisposable
{
    event EventHandler? ShakeDetected;

    bool IsMonitoring { get; }

    void Start(double thresholdG = 2.2, int debounceMs = 800);

    void Stop();
}
