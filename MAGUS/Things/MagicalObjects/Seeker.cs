using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class Seeker : MagicalObject

{
    public override Money Price => new(3);

    public override int ManaPoints => 130;
}
