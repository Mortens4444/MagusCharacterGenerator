using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Gemstones;

public class Opal : Gemstone
{
    public override Money Price => new(120);

    public override string Description => "magic of natural materials";
}