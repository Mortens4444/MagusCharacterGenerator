using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.GameSystem.PoisonsAndIllnesses;

public class TongueSoother : Poison
{
    public override string Name => "Tongue Soother";

    public override Money Price => new(2);
}
