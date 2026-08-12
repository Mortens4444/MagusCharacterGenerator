using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class StaffOfTransformation : MagicalObject
{
    public override string Name => "Staff of Transformation";

    public override Money Price => new(3);

    public override int ManaPoints => 133;
}
