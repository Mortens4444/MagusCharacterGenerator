using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class Peridot : Gemstone
{
    public Peridot() : base("astral") { }

    public override Money Price => new(60);
}