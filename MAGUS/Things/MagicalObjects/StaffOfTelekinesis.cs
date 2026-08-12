using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class StaffOfTelekinesis : MagicalObject
{
    public override string Name => "Staff of Telekinesis";

    public override Money Price => new(3);

    public override int ManaPoints => 73;
}
