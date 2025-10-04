using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.GameSystem.PoisonsAndIllnesses;

public class BlackBlood : Poison
{
    public override string Name => "Black Blood";

    public override Money Price => new(20);
}
