using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.GameSystem;

public class MeleeAttack : Attack
{
    public IMeleeWeapon Weapon { get; init; }

    public MeleeAttack(string name, int value, Func<int> getDamageCallback) : base(name, value, getDamageCallback)
    {
    }

    public MeleeAttack(IMeleeWeapon weapon, int value) : base(weapon.Name, value + weapon.AttackingValue, weapon.GetDamage)
    {
        Weapon = weapon;
    }
}
