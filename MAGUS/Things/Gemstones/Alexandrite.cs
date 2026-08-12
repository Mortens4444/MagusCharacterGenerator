using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Gemstones;

public class Alexandrite : Gemstone
{
    public override Money Price => new(20);

    public override string Description => "demons";
}