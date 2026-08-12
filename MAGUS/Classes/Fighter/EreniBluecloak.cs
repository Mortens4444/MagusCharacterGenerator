using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.GameSystem.Experience;
using MAGUS.GameSystem.FightMode;
using MAGUS.Interfaces;
using MAGUS.Qualifications;
using MAGUS.Qualifications.Combat;
using MAGUS.Qualifications.Laical;
using MAGUS.Qualifications.Scientific;
using MAGUS.Races;
using MAGUS.Things.Weapons.Spears;
using MAGUS.Things.Weapons.StabbingWeapons;

namespace MAGUS.Classes.Fighter;

public class EreniBluecloak : Class, IClass, IJustFight
{
    public EreniBluecloak() : base(1, false) { }

    public EreniBluecloak(int level, bool autoGenerateSkills) : base(level, autoGenerateSkills) { }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(12)]
    [SpecialTraining]
    public override int Strength { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    [SpecialTraining]
    public override int Quickness { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    [SpecialTraining]
    public override int Dexterity { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    [SpecialTraining]
    public override int Stamina { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(10)]
    public override int Health { get; set; }

    [DiceThrow(ThrowType._3D6_2_Times)]
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

    public override int InitiateBaseValue => 9;

    public override int AttackBaseValue => 20;

    public override int DefenseBaseValue => 75;

    public override int AimBaseValue => 0;

    public override int CombatValueModifierPerLevel => 11;

    public override int BaseQualificationPoints => 10;

    public override int QualificationPointsModifier => 14;

    public override int PercentQualificationModifier => 0;

    public override int BaseLifePoints => 7;

    public override int BasePainTolerancePoints => 6;

    public override bool AddCombatModifierOnFirstLevel => true;

    public override bool AddPainToleranceOnFirstLevel => true;

    public override bool AddQualificationPointsOnFirstLevel => true;

    public override List<LevelRequirement> ExperienceLevels =>
    [
        new() { Level = 1,  MinExperience = 0,     MaxExperience = 160 },
        new() { Level = 2,  MinExperience = 161,   MaxExperience = 320 },
        new() { Level = 3,  MinExperience = 321,   MaxExperience = 640 },
        new() { Level = 4,  MinExperience = 641,   MaxExperience = 1440 },
        new() { Level = 5,  MinExperience = 1441,  MaxExperience = 2800 },
        new() { Level = 6,  MinExperience = 2801,  MaxExperience = 5600 },
        new() { Level = 7,  MinExperience = 5601,  MaxExperience = 10000 },
        new() { Level = 8,  MinExperience = 10001, MaxExperience = 20000 },
        new() { Level = 9,  MinExperience = 20001, MaxExperience = 40000 },
        new() { Level = 10, MinExperience = 40001, MaxExperience = 60000 },
        new() { Level = 11, MinExperience = 60001, MaxExperience = 80000 },
        new() { Level = 12, MinExperience = 80001, MaxExperience = 112000 }
    ];

    public override string Name => "Ereni Bluecloak";

    public override ulong ExpPerLevelAfter12 => 31200;

    public override IRace[] AllowedRaces => [new Human(), new Elf(), new HalfElf(), new Dwarf(), new CourtOrc(), new Amund(), new Jann(), new Khal(), new Wier(), new Feenhar(), new Dahr(), new Dracker(), new Draquon(),
        new ForestGiant(), new FrostGiant(), new MountainGiant(), new SwampGiant(), new Gnome(), new CourtGoblin(), new GhoRagg(), new MutantOrc(), new CwyvehKah()];

    public override QualificationList Qualifications => BuildQualifications(
    [
        new WeaponUse() { Weapon = new Longsword() },
        new WeaponUse() { Weapon = new Dagger() },
        new WeaponUse() { Weapon = new BattleAxe() },
        new WeaponUse() { Weapon = new Javelin() },
        new Fistfight(),
        new Wrestling(),
        new Leadership(),
        new MilitaryFormation(),
        new ForestSurvival(),
        new Running()
    ]);

    public override QualificationList FutureQualifications => BuildQualifications(
    [
        new Cartography(level: 3),
        new Healing(level: 4),
        new TwoHandedCombat(level: 4),
        new AnimalTraining(level: 5) { Note = "Horse only" },
    ]);

    public override PercentQualificationList PercentQualifications =>
    [
        //new Hiding(30, level: 6),
    ];

    public override SpecialQualificationList SpecialQualifications => [];

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(4)]
    public override int GetPainToleranceModifier() => DiceThrow._1D6() + 4;
}
