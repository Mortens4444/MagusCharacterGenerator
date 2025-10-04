using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.GameSystem.Gemstones;

public class Topaz : Gemstone
{
    public Topaz() : base("air force") { }

    public override Money Price => new Money(50);
}