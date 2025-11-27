using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class Agate : Gemstone
{
    public Agate() : base("sleep") { }

    public override Money Price => new(2);
}