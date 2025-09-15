using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.OtherWeapons;

public class Lasso : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1/3;

    public byte InitiatingValue => 0;

    public byte AttackingValue => 1;

    public byte DefendingValue => 0;

    public double Weight => 0.6;

    public Money Price => new(0, 0, 80);

    public byte GetDamage() => 0;
}