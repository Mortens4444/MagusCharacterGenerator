using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Things.StabbingWeapons;

public class Sequor : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 2;

    public byte InitiatingValue => 8;

    public byte AttackingValue => 13;

    public byte DefendingValue => 16;

    public override double Weight => 0.4;

    public override Money Price => new(1, 3);

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(2)]
    public byte GetDamage() => (byte)(DiceThrow._1K6() + 2);
}