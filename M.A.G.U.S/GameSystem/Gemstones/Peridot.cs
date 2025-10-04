using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.GameSystem.Gemstones;

public class Peridot : Gemstone
{
    public Peridot() : base("astral") { }

    public override Money Price => new Money(60);
}