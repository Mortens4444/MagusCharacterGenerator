using M.A.G.U.S.Interfaces;
using Newtonsoft.Json;

namespace M.A.G.U.S.GameSystem;

public class MeleeAttack : Attack
{
    public IMeleeWeapon? Weapon { get; init; }

    [JsonConstructor]
    public MeleeAttack() : base() { }

    public MeleeAttack(string name, int value, Func<int> getDamageCallback) : base(name, value, getDamageCallback)
    {
    }

    public MeleeAttack(IMeleeWeapon weapon, int value) : base(weapon.Name, value + weapon.AttackValue, weapon.GetDamage)
    {
        Weapon = weapon;
    }
}
