using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.GameSystem.Gemstones;

public class Chalcedony : Gemstone
{
    public Chalcedony() : base("undeads") { }

    public override Money Price => new Money(4);
}