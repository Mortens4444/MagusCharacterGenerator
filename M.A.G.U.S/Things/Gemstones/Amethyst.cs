using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class Amethyst : Gemstone
{
    public override Money Price => new(10);

    public override string Description => "drunkenness";
}