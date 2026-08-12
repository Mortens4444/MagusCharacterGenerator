using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Gemstones;

public class Agate : Gemstone
{
    public override Money Price => new(2);

    public override string Description => "sleep";
}