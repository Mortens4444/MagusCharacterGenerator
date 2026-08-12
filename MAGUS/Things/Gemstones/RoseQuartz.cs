using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Gemstones;

public class RoseQuartz : Gemstone
{
    public override string Name => "Rose Quartz";

    public override Money Price => new(6);

    public override string Description => "protection, wounds";
}