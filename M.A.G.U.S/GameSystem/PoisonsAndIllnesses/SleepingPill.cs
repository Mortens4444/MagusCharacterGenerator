using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.GameSystem.PoisonsAndIllnesses;

public class SleepingPill : Poison
{
    public override string Name => "Sleeping Pill";

    public override Money Price => new(0, 5);
}
