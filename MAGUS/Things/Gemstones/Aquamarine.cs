using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Gemstones;

public class Aquamarine : Gemstone
{
    public override Money Price => new(50);

    public override string Description => "elementals (primordial water)";
}