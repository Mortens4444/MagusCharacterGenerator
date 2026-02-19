using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class RockCrystal : Gemstone
{
    public override string Name => "Rose Crystal";

    public override Money Price => new(8);

    public override string Description => "elementals (primordial air), ghosts";
}