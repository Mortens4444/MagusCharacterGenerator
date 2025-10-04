using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.GameSystem.PoisonsAndIllnesses;

public class BleedingAgent : Poison
{
    public override string Name => "Bleeding Agent";

    public override Money Price => new(12);
}
