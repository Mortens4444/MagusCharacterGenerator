using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class StaffOfTerror : MagicalObject
{
    public override string Name => "Staff of Terror";

    public override Money Price => new(4);

    public override int ManaPoints => 73;
}
