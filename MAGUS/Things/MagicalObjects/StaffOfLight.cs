using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class StaffOfLight : MagicalObject
{
    public override string Name => "Staff of Light";

    public override Money Price => new(0, 8);

    public override int ManaPoints => 84;
}
