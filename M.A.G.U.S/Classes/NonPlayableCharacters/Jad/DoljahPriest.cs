using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Experience;
using M.A.G.U.S.GameSystem.FightMode;
using M.A.G.U.S.GameSystem.Languages;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Combat;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Percentages;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Qualifications.Specialities;
using M.A.G.U.S.Qualifications.Underworld;
using M.A.G.U.S.Races;

namespace M.A.G.U.S.Classes.NonPlayableCharacters.Jad;

public class DoljahPriest : Class, IClass, IJustFight
{
    public DoljahPriest() : base(1, false) { }

    public DoljahPriest(int level, bool autoGenerateSkills) : base(level, autoGenerateSkills) { }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override int Strength { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    [SpecialTraining]
    public override int Quickness { get; set; }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(12)]
    [SpecialTraining]
    public override int Dexterity { get; set; }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override int Stamina { get; set; }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override int Health { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    public override int Beauty { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    public override int Intelligence { get; set; }

    [DiceThrow(ThrowType._3D6)]
    public override int Willpower { get; set; }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override int Astral { get; set; }

    [DiceThrow(ThrowType._1D10)]
    public override int Gold { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(8)]
    public override int Bravery { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(8)]
    public override int Erudition { get; set; }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(12)]
    public override int Detection { get; set; }

    public override int InitiateBaseValue => 8;

    public override int AttackBaseValue => 17;

    public override int DefenseBaseValue => 72;

    public override int AimBaseValue => 10;

    public override int CombatValueModifierPerLevel => 6;

    public override int BaseQualificationPoints => 8;

    public override int QualificationPointsModifier => 10;

    public override int PercentQualificationModifier => 62;

    public override int BaseLifePoints => 4;

    public override int BasePainTolerancePoints => 5;

    public override bool AddCombatModifierOnFirstLevel => false;

    public override bool AddPainToleranceOnFirstLevel => false;

    public override bool AddQualificationPointsOnFirstLevel => true;

    public override IRace[] AllowedRaces => [new Human(), new Jann()];

    public override List<LevelRequirement> ExperienceLevels =>
    [
        new() { Level = 1,  MinExperience = 0,      MaxExperience = 160 },
        new() { Level = 2,  MinExperience = 161,    MaxExperience = 330 },
        new() { Level = 3,  MinExperience = 331,    MaxExperience = 660 },
        new() { Level = 4,  MinExperience = 661,    MaxExperience = 1300 },
        new() { Level = 5,  MinExperience = 1301,   MaxExperience = 2600 },
        new() { Level = 6,  MinExperience = 2601,   MaxExperience = 5000 },
        new() { Level = 7,  MinExperience = 5001,   MaxExperience = 9000 },
        new() { Level = 8,  MinExperience = 9001,   MaxExperience = 23000 },
        new() { Level = 9,  MinExperience = 23001,  MaxExperience = 50000 },
        new() { Level = 10, MinExperience = 50001,  MaxExperience = 90000 },
        new() { Level = 11, MinExperience = 90001,  MaxExperience = 130000 },
        new() { Level = 12, MinExperience = 130001, MaxExperience = 165000 }
    ];

    public override int ExpPerLevelAfter12 => 50000;

    public override QualificationList Qualifications => BuildQualifications(
    [
        new WeaponUse(),
        new WeaponUse(),
        new WeaponThrowing(),
        new LanguageLore(Language.Pyarronian, 3),
        new LanguageLore(Language.Shadonian, 2),
        new LanguageLore(Language.Toronian, 2),
        new Appraisal(),
        new TavernBrawling()
    ]);

    public override QualificationList FutureQualifications => BuildQualifications(
    [
        new EscapeBonds(level: 2),
        new Knotting(level: 3),
        new Backstab(level: 3),
        new TavernBrawling(QualificationLevel.Master, 4),
        new WeaponThrowing(QualificationLevel.Master, 5)
    ]);

    public override PercentQualificationList PercentQualifications =>
    [
        new Climbing(45),
        new Falling(15),
        new Jumping(10),
        new LockPicking(25),
        new Sneaking(30),
        new Hiding(15),
        new TightropeWalking(25),
        new PickPocketing(25),
        new TrapDetection(25),
        new SecretDoorSearch(15),
    ];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new ThiefInitiateValueIncreasing()
    ];

    public override string Name => "Priest of Doljah";

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(3)]
    public override int GetPainToleranceModifier() => DiceThrow._1D6() + 3;
}
