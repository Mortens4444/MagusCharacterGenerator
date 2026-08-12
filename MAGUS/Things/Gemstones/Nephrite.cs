using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Gemstones;

public class Nephrite : Gemstone
{
    public override Money Price => new(9);

    public override string Description => "elementals (elemental force)";
}