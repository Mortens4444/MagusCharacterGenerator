using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Gemstones;

public class SmokyQuartz : Gemstone
{
    public override string Name => "Smoky Quartz";

    public override Money Price => new(7);

    public override string Description => "orientation, cardinal directions, term magic";
}