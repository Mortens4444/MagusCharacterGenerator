using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Gemstones;

public class Zircon : Gemstone
{
    public override Money Price => new(5);

    public override string Description => "time, time magic";
}