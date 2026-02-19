using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class Agate : Gemstone
{
    public override Money Price => new(2);

    public override string Description => "sleep";
}