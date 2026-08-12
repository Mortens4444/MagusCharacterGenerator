using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Gemstones;

public class Obsidian : Gemstone
{
    public override Money Price => new(3);

    public override string Description => "necromancy";
}