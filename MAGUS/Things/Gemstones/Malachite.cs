using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Gemstones;

public class Malachite : Gemstone
{
    public override Money Price => new(1);

    public override string Description => "effects unknown";
}