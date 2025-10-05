using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class WeaponStaff : MagicalObject
{
    public override string Name => "Weapon Staff";

    public override Money Price => new(3);

    public override int ManaPoints => 108;
}
