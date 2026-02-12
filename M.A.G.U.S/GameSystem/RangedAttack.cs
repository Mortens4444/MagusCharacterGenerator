using M.A.G.U.S.Interfaces;
using Newtonsoft.Json;

namespace M.A.G.U.S.GameSystem;

public class RangedAttack : Attack
{
    public IRangedWeapon Weapon { get; init; }

    [JsonConstructor]
    public RangedAttack() : base() { }

    //public RangeAttack(string name, int aimValue, Func<int> getDamageCallback) : base(name, aimValue, getDamageCallback)
    //{
    //}

    public RangedAttack(IRangedWeapon weapon, int value) : base(weapon.Name, value + weapon.AimValue, weapon.GetDamage)
    {
        Weapon = weapon;
    }
}
