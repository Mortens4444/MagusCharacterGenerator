using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class Peridot : Gemstone
{
    public override Money Price => new(60);

    public override string Description => "astral";
}