using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class Aquamarine : Gemstone
{
    public override Money Price => new(50);

    public override string Description => "elementals (primordial water)";
}