using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class Sapphire : Gemstone
{
    public override Money Price => new(200);

    public override string Description => "magic resistance, counterspell";

}