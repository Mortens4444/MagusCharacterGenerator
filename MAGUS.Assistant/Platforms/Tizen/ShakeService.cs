using MAGUS.Assistant.Interfaces;

namespace MAGUS.Assistant.Platforms.Tizen;

internal sealed class ShakeService : IShakeService
{
    public bool IsMonitoring => false;

    public event EventHandler? ShakeDetected;

    public void Start(double thresholdG = 2.2, int debounceMs = 800)
    {
    }

    public void Stop()
    {
    }

    public void Dispose()
    {
    }
}
