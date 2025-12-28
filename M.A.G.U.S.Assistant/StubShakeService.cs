using M.A.G.U.S.Assistant.Interfaces;

namespace M.A.G.U.S.Assistant;

internal partial class StubShakeService : IShakeService
{
    public bool IsMonitoring => throw new NotImplementedException();

    public event EventHandler? ShakeDetected;

    public void Dispose()
    {
    }

    public void Start(double thresholdG = 2.2, int debounceMs = 800)
    {
    }

    public void Stop()
    {
    }
}
