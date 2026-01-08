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
using M.A.G.U.S.Qualifications.Magic;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Races;

namespace M.A.G.U.S.Classes.Sorcerer;

/// <summary>
/// https://kalandozok.hu/magus/atlantisz/jatszhatokasztok/magiahasznalo/varazslo/legvarazslo(ismeretlen)atlantisz.pdf
/// </summary>
public class AirWizard : Class, IClass, ILikeMagic
{
    public AirWizard() : base(1, false) { }

    public AirWizard(int level, bool autoGenerateSkills) : base(level, autoGenerateSkills) { }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(2)]
    [SpecialTraining]

    public override int Strength { get; set; }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override int Quickness { get; set; }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override int Dexterity { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    public override int Stamina { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    public override int Health { get; set; }

    [DiceThrow(ThrowType._3D6)]
    public override int Beauty { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    [SpecialTraining]
    public override int Intelligence { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    public override int Willpower { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
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

    public override int InitiateBaseValue => 7;

    public override int AttackBaseValue => 18;

    public override int DefenseBaseValue => 73;

    public override int AimBaseValue => 15;

    public override int CombatValueModifierPerLevel => 9;

    public override int BaseQualificationPoints => 6;

    public override int QualificationPointsModifier => 8;

    public override int PercentQualificationModifier => 0;

    public override int BaseLifePoints => 5;

    public override int BasePainTolerancePoints => 5;

    public override bool AddCombatModifierOnFirstLevel => false;

    public override bool AddPainToleranceOnFirstLevel => false;

    public override bool AddQualificationPointsOnFirstLevel => true;

    public override IRace[] AllowedRaces => [new Feenhar(), new Dahr(), new Draquon()];

    public override List<LevelRequirement> ExperienceLevels =>
    [
        new() { Level = 1,  MinExperience = 0,      MaxExperience = 170 },
        new() { Level = 2,  MinExperience = 171,    MaxExperience = 350 },
        new() { Level = 3,  MinExperience = 351,    MaxExperience = 700 },
        new() { Level = 4,  MinExperience = 701,    MaxExperience = 1500 },
        new() { Level = 5,  MinExperience = 1501,   MaxExperience = 3000 },
        new() { Level = 6,  MinExperience = 3001,   MaxExperience = 7000 },
        new() { Level = 7,  MinExperience = 7001,   MaxExperience = 12000 },
        new() { Level = 8,  MinExperience = 12001,  MaxExperience = 22000 },
        new() { Level = 9,  MinExperience = 22001,  MaxExperience = 52500 },
        new() { Level = 10, MinExperience = 52501,  MaxExperience = 85500 },
        new() { Level = 11, MinExperience = 85501,  MaxExperience = 135000 },
        new() { Level = 12, MinExperience = 135001, MaxExperience = 175500 }
    ];

    public override int ExpPerLevelAfter12 => 58500;

    public override QualificationList Qualifications => BuildQualifications(
    [
        new WeaponUse(),
        new WeaponThrowing(),
        new ReadingAndWriting(),
        new Fistfight(),
        new ForestSurvival(),
        new Cartography(),
        new HuntingAndFishing(),
        new LanguageLore(Language.Pyarronian, 5),
        new LanguageLore(Language.Shadonian, 4),
    ]);

    public override QualificationList FutureQualifications => BuildQualifications(
    [
        new WeaponUse(level: 2),
        new Healing(level: 3),
        new Cartography(QualificationLevel.Master, 4),
        new WeaponUse(QualificationLevel.Master, 5)
    ]);

    public override PercentQualificationList PercentQualifications => [];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new FireMagic()
    ];

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(1)]
    public override int GetPainToleranceModifier() => DiceThrow._1D6() + 1;

    public override string Name => "Air Wizard";
}
