using M.A.G.U.S.Things.Weapons;
using Newtonsoft.Json;

namespace M.A.G.U.S.GameSystem;

public class RangeAttack : Attack
{
    public IRangedWeapon Weapon { get; init; }

    [JsonConstructor]
    public RangeAttack() : base() { }

    //public RangeAttack(string name, int aimValue, Func<int> getDamageCallback) : base(name, aimValue, getDamageCallback)
    //{
    //}

    public RangeAttack(IRangedWeapon weapon, int value) : base(weapon.Name, value + weapon.AimValue, weapon.GetDamage)
    {
        Weapon = weapon;
    }
}
