using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class StealthFootwear : MagicalObject
{
    public override string Name => "Stealth Footwear";

    public override Money Price => new(2);

    public override int ManaPoints => 73;
}
