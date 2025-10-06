using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.OtherWeapons;

public class ThrowingNet : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1 / 3;

    public byte InitiatingValue => 1;

    public byte AttackingValue => 8;

    public byte DefendingValue => 4;

    public override double Weight => 1;

    public override Money Price => new(0, 3);

    public byte GetDamage() => 0;

    public override string Name => "Throwing net";
}