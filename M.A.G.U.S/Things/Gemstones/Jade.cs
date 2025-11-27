using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class Jade : Gemstone
{
    public Jade() : base("music, singing, dance, sounds") { }

    public override Money Price => new(15);
}