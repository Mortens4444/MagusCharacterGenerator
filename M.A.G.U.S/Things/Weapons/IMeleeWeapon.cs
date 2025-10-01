using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Weapons;

public interface IMeleeWeapon : IWeapon
{
    byte AttackingValue { get; }

    byte DefendingValue { get; }
}