using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;
using MAGUS.Things.Weapons.CrushingWeapons;
using MAGUS.Things.Weapons.RangedWeapons;
using MAGUS.Things.Weapons.StabbingWeapons;

namespace MAGUS.Bestiary.Races;

public sealed class Orc : Creature
{
    public Orc()
    {
        Occurrence = Occurrence.Frequent;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.DeepUnderground;

        AttackValue = 55;
        DefenseValue = 85;
        InitiateValue = 20;
        AimValue = 0;

        AttackModes =
        [
            new MeleeAttack(new Warhammer(), AttackValue),
            new MeleeAttack(new TwoHandedMace(), AttackValue),
            new MeleeAttack(new ShortSword(), AttackValue),
            new MeleeAttack(new Longsword(), AttackValue),
            new RangedAttack(new Shortbow(), AimValue),
            new RangedAttack(new Longbow(), AimValue)
        ];

        HealthPoints = 10;
        PainTolerancePoints = 16;

        PoisonResistance = 3;

        Intelligence = Enums.Intelligence.Low;
        Alignment = Alignment.Chaos;
        ExperiencePoints = 30;
    }

    [DiceThrow(ThrowType._1D10)]
    public override int GetDamage() => DiceThrow._1D10();

    [DiceThrow(ThrowType._10D10)]
    public override int GetNumberAppearing() => DiceThrow._10D10();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 100)];

    public override string[] Sounds => ["orc_ouch"];
}
