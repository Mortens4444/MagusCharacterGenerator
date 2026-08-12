using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Gemstones;

public class Pearl : Gemstone
{
    public override Money Price => new(300);

    public override string Description => "healing";
}