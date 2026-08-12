using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Gemstones;

public class Diamond : Gemstone
{
    public override Money Price => new(500);

    public override string Description => "undead, poisons, illnesses";
}