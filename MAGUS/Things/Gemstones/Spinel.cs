using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Gemstones;

public class Spinel : Gemstone
{
    public override Money Price => new(40);

    public override string Description => "combat";
}