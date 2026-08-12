using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class PotionOfCourage : MagicalObject
{
    public override string Name => "Potion of Courage";

    public override Money Price => new(5);

    public override int ManaPoints => 50;
}
