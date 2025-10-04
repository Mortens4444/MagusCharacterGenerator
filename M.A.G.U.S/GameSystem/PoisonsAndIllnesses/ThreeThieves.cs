using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.GameSystem.PoisonsAndIllnesses;

public class ThreeThieves : Poison
{
    public override string Name => "Three Thieves";

    public override Money Price => new Money(900);
}
