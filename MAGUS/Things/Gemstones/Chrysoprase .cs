using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Gemstones;

public class Chrysoprase : Gemstone
{
    public override Money Price => new(5);

    public override string Description => "invisibility, stealth";
}