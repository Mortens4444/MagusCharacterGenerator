using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Gemstones;

public class Chrysoberyl : Gemstone
{
    public override Money Price => new(10);

    public override string Description => "soul";
}