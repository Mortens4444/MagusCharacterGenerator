using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Things.StabbingWeapons;

public class JadJambiya : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 2;

    public byte InitiatingValue => 10;

    public byte AttackingValue => 12;

    public byte DefendingValue => 15;

    public override double Weight => 0.8;

    public override Money Price => new(60);

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(1)]
    public byte GetDamage() => (byte)(DiceThrow._1K6() + 1);

    public override string Name => "Jad jambiya";
}