using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class Sapphire : Gemstone
{
    public Sapphire() : base("magic resistance, counterspell") { }

    public override Money Price => new(200);

}