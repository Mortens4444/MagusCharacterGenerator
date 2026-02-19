using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class Ruby : Gemstone
{
    public override Money Price => new(500);

    public override string Description => "general magical stone";
}