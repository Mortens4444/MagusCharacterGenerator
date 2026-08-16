using MAGUS.Interfaces;
using Newtonsoft.Json;

namespace MAGUS.GameSystem;

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

    public MeleeAttack(IMeleeWeapon weapon, int value, int damageBonus)
        : base(weapon.Name, value + weapon.AttackValue, () => weapon.GetDamage() + damageBonus)
    {
        Weapon = weapon;
    }
}
