using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Gemstones;

public class Peridot : Gemstone
{
    public override Money Price => new(60);

    public override string Description => "astral";
}