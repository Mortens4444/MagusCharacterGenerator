using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Things.StabbingWeapons;

public class KnightSword : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public byte InitiatingValue => 2;

    public byte AttackingValue => 10;

    public byte DefendingValue => 7;

    public override double Weight => 3.5;

    public override Money Price => new(3);

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(6)]
    public byte GetDamage() => (byte)(DiceThrow._2K6() + 6);

    public override string Name => "Knight’s sword";
}