using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.GameSystem.Gemstones;

public class Sapphire : Gemstone
{
    public Sapphire() : base("magic resistance, counterspell") { }

    public override Money Price => new Money(200);

}