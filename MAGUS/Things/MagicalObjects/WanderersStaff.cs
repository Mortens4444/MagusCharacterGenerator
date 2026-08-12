using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class WanderersStaff : MagicalObject
{
    public override string Name => "Wanderer's Staff";

    public override Money Price => new(0, 3);

    public override int ManaPoints => 63;
}
