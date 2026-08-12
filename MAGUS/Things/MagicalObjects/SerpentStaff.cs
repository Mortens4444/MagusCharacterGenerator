using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class SerpentStaff : MagicalObject
{
    public override string Name => "Serpent Staff";

    public override Money Price => new(6);

    public override int ManaPoints => 58;
}
