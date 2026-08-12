using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.GameSystem.Experience;
using MAGUS.GameSystem.FightMode;
using MAGUS.GameSystem.Qualifications;
using MAGUS.Interfaces;
using MAGUS.Qualifications;
using MAGUS.Qualifications.Combat;
using MAGUS.Qualifications.Laical;
using MAGUS.Qualifications.Percentages;
using MAGUS.Qualifications.Scientific;
using MAGUS.Qualifications.Specialities;
using MAGUS.Races;
using MAGUS.Things.Weapons.RangedWeapons;
using MAGUS.Things.Weapons.Spears;
using MAGUS.Things.Weapons.StabbingWeapons;

namespace MAGUS.Classes.Fighter;

public class Amazon : Class, IClass, IJustFight
{
    public Amazon() : base(1, false) { }

    public Amazon(int level, bool autoGenerateSkills) : base(level, autoGenerateSkills) { }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    public override int Strength { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    public override int Quickness { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    public override int Dexterity { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    public override int Stamina { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    public override int Health { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    public override int Beauty { get; set; }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override int Intelligence { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    public override int Willpower { get; set; }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override int Astral { get; set; }

    [DiceThrow(ThrowType._3D6)]
    public override int Gold { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(8)]
    public override int Bravery { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(8)]
    public override int Erudition { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    public override int Detection { get; set; }

    public override int InitiateBaseValue => 8;

    public override int AttackBaseValue => 22;

    public override int DefenseBaseValue => 73;

    public override int AimBaseValue => 10;

    public override int CombatValueModifierPerLevel => 10;

    public override int BaseQualificationPoints => 8;

    public override int QualificationPointsModifier => 8;

    public override int PercentQualificationModifier => 0;

    public override int BaseLifePoints => 7;

    public override int BasePainTolerancePoints => 7;

    public override bool AddCombatModifierOnFirstLevel => false;

    public override bool AddPainToleranceOnFirstLevel => false;

    public override bool AddQualificationPointsOnFirstLevel => false;

    public override List<LevelRequirement> ExperienceLevels =>
    [
        new() { Level = 1,  MinExperience = 0,     MaxExperience = 185 },
        new() { Level = 2,  MinExperience = 186,   MaxExperience = 372 },
        new() { Level = 3,  MinExperience = 373,   MaxExperience = 744 },
        new() { Level = 4,  MinExperience = 745,   MaxExperience = 1488 },
        new() { Level = 5,  MinExperience = 1489,  MaxExperience = 2976 },
        new() { Level = 6,  MinExperience = 2977,  MaxExperience = 5952 },
        new() { Level = 7,  MinExperience = 5953,  MaxExperience = 11900 },
        new() { Level = 8,  MinExperience = 11901, MaxExperience = 23800 },
        new() { Level = 9,  MinExperience = 23801, MaxExperience = 47600 },
        new() { Level = 10, MinExperience = 47601, MaxExperience = 71400 },
        new() { Level = 11, MinExperience = 71401, MaxExperience = 101000 },
        new() { Level = 12, MinExperience = 101001, MaxExperience = 151000 }
    ];

    public override ulong ExpPerLevelAfter12 => 31200;

    public override IRace[] AllowedRaces => [new Human(), new Elf(), new HalfElf(), new Dwarf(), new CourtOrc(), new Amund(), new Jann(), new Khal(), new Wier(), new Feenhar(), new Dahr(), new Dracker(), new Draquon(),
        new ForestGiant(), new FrostGiant(), new MountainGiant(), new SwampGiant(), new Gnome(), new CourtGoblin(), new GhoRagg(), new MutantOrc(), new CwyvehKah()];

    public override QualificationList Qualifications => BuildQualifications(
    [
        new WeaponUse() { Weapon = new Longsword() },
        new WeaponUse() { Weapon = new Dagger() },
        new WeaponUse() { Weapon = new Longbow() },
        new WeaponUse() { Weapon = new Javelin() },
        new WeaponThrowing() { Weapon = new Dagger() },
        new WeatherDivination(),
        new Herbalism(),
        new Running(),
        new Onomatopoeia(),
        new TrackingConcealment(),
        new TrapSetting(),
        new Riding(QualificationLevel.Master),
        new SexualCulture(QualificationLevel.Master),
        new Bloodlust(QualificationLevel.Master),
        new ForestSurvival(QualificationLevel.Master),
        new HuntingAndFishing(QualificationLevel.Master)
    ]); 

    public override QualificationList FutureQualifications => BuildQualifications(
    [
    ]);

    public override PercentQualificationList PercentQualifications =>
    [
        new Persuasion(Level * 12)
    ];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new BetterResistanceToLieDetection(70)
    ];

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(4)]
    public override int GetPainToleranceModifier() => DiceThrow._1D6() + 4;
}
