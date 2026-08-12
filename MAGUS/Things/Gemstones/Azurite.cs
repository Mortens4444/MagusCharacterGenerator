using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Gemstones;

public class Azurite : Gemstone
{
    public override Money Price => new(1);

    public override string Description => "astrology, celestial bodies";
}