using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class WeaponStaff : MagicalObject
{
    public override string Name => "Weapon Staff";

    public override Money Price => new(3);

    public override int ManaPoints => 108;
}
