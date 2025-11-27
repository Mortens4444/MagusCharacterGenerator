using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class Topaz : Gemstone
{
    public Topaz() : base("air force") { }

    public override Money Price => new(50);
}