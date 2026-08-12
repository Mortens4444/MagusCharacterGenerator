 using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class DragonStaff : MagicalObject
{
    public override string Name => "Dragon Staff";

    public override Money Price => new(4);

    public override int ManaPoints => 93;
}
