using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class Garnet : Gemstone
{
    public override Money Price => new(30);

    public override string Description => "elementals (primordial fire)";
}