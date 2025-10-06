using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.OtherWeapons;

public class Fist : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 2;

    public byte InitiatingValue => 10;

    public byte AttackingValue => 4;

    public byte DefendingValue => 1;

    public override double Weight => 0;

    public override Money Price => Money.Free;

    [DiceThrow(ThrowType._1K2)]
    public byte GetDamage() => (byte)DiceThrow._1K2();
}