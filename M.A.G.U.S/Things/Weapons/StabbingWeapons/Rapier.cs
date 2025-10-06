using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Things.StabbingWeapons;

public class Rapier : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 2;

    public byte InitiatingValue => 9;

    public byte AttackingValue => 12;

    public byte DefendingValue => 14;

    public override double Weight => 0.8;

    public override Money Price => new(2);

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(2)]
    public byte GetDamage() => (byte)(DiceThrow._1K6() + 2);
}