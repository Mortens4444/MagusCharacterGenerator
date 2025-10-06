using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Things.StabbingWeapons;

public class ElvenDagger : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 2;

    public byte InitiatingValue => 9;

    public byte AttackingValue => 9;

    public byte DefendingValue => 2;

    public override double Weight => 0.2;

    public override Money Price => new(5);

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(1)]
    public byte GetDamage() => (byte)(DiceThrow._1K6() + 1);

    public override string Name => "Elven dagger";
}