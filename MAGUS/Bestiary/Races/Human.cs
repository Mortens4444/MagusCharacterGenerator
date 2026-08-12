using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;
using MAGUS.Things.Weapons.CrushingWeapons;
using MAGUS.Things.Weapons.RangedWeapons;
using MAGUS.Things.Weapons.StabbingWeapons;

namespace MAGUS.Bestiary.Races;

public sealed class Human : Creature
{
    public Human()
    {
        Occurrence = Occurrence.Frequent;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.Urban;

        AttackValue = 45;
        DefenseValue = 95;
        InitiateValue = 30;
        AimValue = 10;

        AttackModes =
        [
            new MeleeAttack(new ShortSword(), AttackValue),
            new MeleeAttack(new Longsword(), AttackValue),
            new MeleeAttack(new Warhammer(), AttackValue),
            new MeleeAttack(new TwoHandedMace(), AttackValue),
            new RangedAttack(new Shortbow(), AimValue),
            new RangedAttack(new Longbow(), AimValue)
        ];

        HealthPoints = 8;
        PainTolerancePoints = 12;

        PoisonResistance = 2;

        Intelligence = Enums.Intelligence.Average;
        Alignment = Alignment.Various;
        ExperiencePoints = 30;
    }

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    [DiceThrow(ThrowType._1D10)]
    public override int GetNumberAppearing() => DiceThrow._1D10();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 100)];
}
