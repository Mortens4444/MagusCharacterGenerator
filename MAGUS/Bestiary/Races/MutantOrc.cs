using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;
using MAGUS.Things.Armors;
using MAGUS.Things.Weapons.CrushingWeapons;
using MAGUS.Things.Weapons.RangedWeapons;
using MAGUS.Things.Weapons.StabbingWeapons;

namespace MAGUS.Bestiary.Races;

public sealed class MutantOrc : Creature
{
    public MutantOrc()
    {
        Armor = new NaturalArmor(3);
        Occurrence = Occurrence.Rare;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.CursedLand;

        AttackValue = 65;
        DefenseValue = 95;
        InitiateValue = 35;
        AimValue = 15;

        AttackModes =
        [
            new MeleeAttack(new Warhammer(), AttackValue),
            new MeleeAttack(new TwoHandedMace(), AttackValue),
            new MeleeAttack(new ShortSword(), AttackValue),
            new MeleeAttack(new Longsword(), AttackValue),
            new RangedAttack(new Shortbow(), AimValue),
            new RangedAttack(new Longbow(), AimValue)
        ];

        HealthPoints = 14;
        PainTolerancePoints = 27;

        PoisonResistance = Int32.MaxValue;
        AstralMagicResistance = 25;
        MentalMagicResistance = 15;

        MinIntelligence = Enums.Intelligence.Low;
        MaxIntelligence = Enums.Intelligence.High;
        Alignment = Alignment.ChaosDeath;
        ExperiencePoints = 45;
    }

    [DiceThrow(ThrowType._1D10)]
    public override int GetDamage() => DiceThrow._1D10();

    [DiceThrow(ThrowType._6D6)]
    public override int GetNumberAppearing() => DiceThrow._6D6();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 120), new Speed(TravelMode.InTheAir, 50)];

    public override string Name => "Mutant orc";

    public override string[] Sounds => ["orc_ouch"];
}
