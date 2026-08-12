using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class StaffOfSpellbreaking : MagicalObject
{
    public override string Name => "Staff of Spellbreaking";

    public override Money Price => new(1);

    public override int ManaPoints => 133;
}
