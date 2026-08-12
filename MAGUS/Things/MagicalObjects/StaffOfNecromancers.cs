using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class StaffOfNecromancers : MagicalObject
{
    public override string Name => "Staff of Necromancers";

    public override Money Price => new(5);

    public override int ManaPoints => 90;
}
