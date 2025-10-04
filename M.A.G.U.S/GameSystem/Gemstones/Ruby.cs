using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.GameSystem.Gemstones;

public class Ruby : Gemstone
{
    public Ruby() : base("general magical stone") { }

    public override Money Price => new Money(500);
}