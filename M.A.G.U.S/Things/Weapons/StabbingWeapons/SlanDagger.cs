using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.StabbingWeapons;

public class SlanDagger : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 2;

    public byte InitiatingValue => 9;

    public byte AttackingValue => 14;

    public byte DefendingValue => 6;

    public override double Weight => 0.8;

    public override Money Price => new(70);

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(2)]
    public byte GetDamage() => (byte)(DiceThrow._1K6() + 2);

    public override string Name => "Slan dagger";

    public override string Description => "A sinister, often serrated or wickedly curved dagger associated with the dark rituals or assassination styles of the Slan cults.";
}