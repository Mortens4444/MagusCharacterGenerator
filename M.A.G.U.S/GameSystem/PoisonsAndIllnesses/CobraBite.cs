using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.GameSystem.PoisonsAndIllnesses;

public class CobraBite : Poison
{
    public override string Name => "Cobra Bite";

    public override Money Price => new(12);
}
