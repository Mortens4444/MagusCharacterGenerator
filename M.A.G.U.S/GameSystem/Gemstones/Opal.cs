using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.GameSystem.Gemstones;

public class Opal : Gemstone
{
    public Opal() : base("magic of natural materials") { }

    public override Money Price => new Money(120);
}