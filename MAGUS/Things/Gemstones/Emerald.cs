using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Gemstones;

public class Emerald : Gemstone
{
    public override Money Price => new(300);

    public override string Description => "general magical stone";
}