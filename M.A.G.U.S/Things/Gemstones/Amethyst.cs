using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class Amethyst : Gemstone
{
    public Amethyst() : base("drunkenness") { }

    public override Money Price => new Money(10);
}