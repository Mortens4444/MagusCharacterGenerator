using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.GameSystem.Valuables;
using MAGUS.Interfaces;

namespace MAGUS.Things.Weapons.StabbingWeapons;

public class ThrowingDagger : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 2;

    public override int InitiateValue => 10;

    public int AttackValue => 11;

    public int DefenseValue => 2;

    public override double Weight => 0.5;

    public override Money Price => new(0, 1, 50);

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    public override string Name => "Throwing dagger";

    public override string Description => "A light, well-balanced dagger designed solely for accuracy and swift flight. Used as a surprise attack or to disable a retreating enemy.";
}