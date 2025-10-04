using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.GameSystem.PoisonsAndIllnesses;

public class HempGrass : Poison
{
    public override string Name => "Hemp Grass";

    public override Money Price => new(1);
}
