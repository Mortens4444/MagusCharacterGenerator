using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Gemstones;

public class Chalcedony : Gemstone
{
    public override Money Price => new(4);

    public override string Description => "undead";
}