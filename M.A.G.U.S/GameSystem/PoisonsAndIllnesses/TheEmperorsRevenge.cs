using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.GameSystem.PoisonsAndIllnesses;

public class TheEmperorsRevenge : Poison
{
    public override string Name => "The Emperor's Revenge";

    public override Money Price => new(100);
}
