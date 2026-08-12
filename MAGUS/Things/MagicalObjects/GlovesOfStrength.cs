using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class GlovesOfStrength : MagicalObject
{
    public override string Name => "Gloves of Strength";

    public override Money Price => new(3);

    public override int ManaPoints => 73;
}
