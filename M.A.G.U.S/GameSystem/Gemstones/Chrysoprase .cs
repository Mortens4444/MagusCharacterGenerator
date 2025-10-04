using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.GameSystem.Gemstones;

public class Chrysoprase : Gemstone
{
    public Chrysoprase() : base("invisibility, stealth") { }

    public override Money Price => new Money(5);
}