using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Gemstones;

public class Turquoise : Gemstone
{
    public override Money Price => new(2);

    public override string Description => "horses, riding";
}