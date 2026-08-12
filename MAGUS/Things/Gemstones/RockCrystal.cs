using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Gemstones;

public class RockCrystal : Gemstone
{
    public override string Name => "Rose Crystal";

    public override Money Price => new(8);

    public override string Description => "elementals (primordial air), ghosts";
}