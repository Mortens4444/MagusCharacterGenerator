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
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Races;

namespace M.A.G.U.S.Classes.Believer;

public abstract class Paladin : Class, IClass, IHateRangedWeapons
{
    public Paladin() : base(1, false) { }

    public Paladin(int level, bool autoGenerateSkills) : base(level, autoGenerateSkills) { }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
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
    [DiceThrowModifier(10)]
    public override int Health { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    public override int Beauty { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    public override int Intelligence { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    public override int Willpower { get; set; }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(12)]
    public override int Astral { get; set; }

    [DiceThrow(ThrowType._1D6)]
    public override int Gold { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(8)]
    public override int Bravery { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(8)]
    public override int Erudition { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    public override int Detection { get; set; }

    public override int InitiateBaseValue => 5;

    public override int AttackBaseValue => 20;

    public override int DefenseBaseValue => 75;

    public override int AimBaseValue => 0;

    public override int CombatValueModifierPerLevel => 9;

    public override int BaseQualificationPoints => 5;

    public override int QualificationPointsModifier => 5;

    public override int PercentQualificationModifier => 0;

    public override int BaseLifePoints => 8;

    public override int BasePainTolerancePoints => 7;

    public override bool AddCombatModifierOnFirstLevel => false;

    public override bool AddPainToleranceOnFirstLevel => false;

    public override bool AddQualificationPointsOnFirstLevel => true;

    public override IRace[] AllowedRaces => [new Human(), new Amund(), new Jann(), new Wier()];

    public override List<LevelRequirement> ExperienceLevels =>
    [
        new() { Level = 1,  MinExperience = 0,      MaxExperience = 175 },
        new() { Level = 2,  MinExperience = 176,    MaxExperience = 352 },
        new() { Level = 3,  MinExperience = 353,    MaxExperience = 720 },
        new() { Level = 4,  MinExperience = 721,    MaxExperience = 1500 },
        new() { Level = 5,  MinExperience = 1501,   MaxExperience = 3500 },
        new() { Level = 6,  MinExperience = 3501,   MaxExperience = 7000 },
        new() { Level = 7,  MinExperience = 7001,   MaxExperience = 10500 },
        new() { Level = 8,  MinExperience = 10501,  MaxExperience = 21000 },
        new() { Level = 9,  MinExperience = 21001,  MaxExperience = 48000 },
        new() { Level = 10, MinExperience = 48001,  MaxExperience = 78000 },
        new() { Level = 11, MinExperience = 78001,  MaxExperience = 108000 },
        new() { Level = 12, MinExperience = 108001, MaxExperience = 138000 }
    ];

    public override ulong ExpPerLevelAfter12 => 38000;
    
    public override QualificationList Qualifications => BuildQualifications(
    [
        new WeaponUse(),
        new WeaponUse(),
        new WeaponUse(),
        new WeaponUse(),
        new PsiPyarron(QualificationLevel.Master),
        new LanguageLore(Language.Pyarronian, 5),
        new LanguageLore(Language.Shadonian, 4),
        new HeavyArmorWearing(),
        new ShieldUse(),
        new Leadership(),
        new ReadingAndWriting(),
        new ReligionLore(),
        new Etiquette(),
        new Heraldry(),
        new Riding(QualificationLevel.Master),
        new SingingAndMakingMusic(),
        new HistoryLore()
    ]);

    public override QualificationList FutureQualifications => BuildQualifications([]);

    public override PercentQualificationList PercentQualifications => [];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new ClericalMagic()
    ];

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(5)]
    public override int GetPainToleranceModifier() => DiceThrow._1D6() + 5;
}
