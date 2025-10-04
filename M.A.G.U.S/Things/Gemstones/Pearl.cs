using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class Pearl : Gemstone
{
    public Pearl() : base("healing") { }

    public override Money Price => new Money(300);
}