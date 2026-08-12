using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Gemstones;

public class Amber : Gemstone
{
    public override Money Price => new(20);

    public override string Description => "illnesses";
}