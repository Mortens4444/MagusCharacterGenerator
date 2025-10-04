using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.GameSystem.Gemstones;

public class Azurite : Gemstone
{
    public Azurite() : base("astrology, celestial bodies") { }

    public override Money Price => new Money(1);
}