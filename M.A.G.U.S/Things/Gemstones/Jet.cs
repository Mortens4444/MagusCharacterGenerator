using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class Jet : Gemstone
{
    public override Money Price => new(12);

    public override string Description => "elementals (primordial earth)";
}