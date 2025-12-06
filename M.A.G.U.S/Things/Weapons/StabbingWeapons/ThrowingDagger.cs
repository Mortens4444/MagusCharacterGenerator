using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.StabbingWeapons;

public class ThrowingDagger : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 2;

    public int InitiatingValue => 10;

    public int AttackingValue => 11;

    public int DefendingValue => 2;

    public override double Weight => 0.5;

    public override Money Price => new(0, 1, 50);

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    public override string Name => "Throwing dagger";

    public override string Description => "A light, well-balanced dagger designed solely for accuracy and swift flight. Used as a surprise attack or to disable a retreating enemy.";
}