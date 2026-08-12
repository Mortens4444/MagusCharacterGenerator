using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Gemstones;

public class Topaz : Gemstone
{
    public override Money Price => new(50);

    public override string Description => "air force";
}