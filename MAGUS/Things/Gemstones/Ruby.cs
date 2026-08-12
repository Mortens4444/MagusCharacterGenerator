using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Gemstones;

public class Ruby : Gemstone
{
    public override Money Price => new(500);

    public override string Description => "general magical stone";
}