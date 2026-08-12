using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Gemstones;

public class Sapphire : Gemstone
{
    public override Money Price => new(200);

    public override string Description => "magic resistance, counterspell";

}