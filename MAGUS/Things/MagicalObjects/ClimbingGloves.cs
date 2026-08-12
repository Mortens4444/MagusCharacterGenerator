using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class ClimbingGloves : MagicalObject
{
    public override string Name => "Climbing Gloves";

    public override Money Price => new(3);

    public override int ManaPoints => 48;
}
