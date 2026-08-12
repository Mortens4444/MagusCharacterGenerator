using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Gemstones;

public class Jet : Gemstone
{
    public override Money Price => new(12);

    public override string Description => "elementals (primordial earth)";
}