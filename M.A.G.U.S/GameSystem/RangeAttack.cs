using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.GameSystem;

public class RangeAttack : Attack
{
    public IRangedWeapon Weapon { get; init; }

    //public RangeAttack(string name, int aimValue, Func<int> getDamageCallback) : base(name, aimValue, getDamageCallback)
    //{
    //}

    public RangeAttack(IRangedWeapon weapon, int value) : base(weapon.Name, value + weapon.AimingValue, weapon.GetDamage)
    {
        Weapon = weapon;
    }
}
