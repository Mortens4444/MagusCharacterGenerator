using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Gemstones;

public class Garnet : Gemstone
{
    public override Money Price => new(30);

    public override string Description => "elementals (primordial fire)";
}