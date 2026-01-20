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

namespace M.A.G.U.S.Classes.Sorcerer;

public class Witch : Class, IClass, ILikeMagic
{
    public Witch() : base(1, false) { }

    public Witch(int level, bool autoGenerateSkills) : base(level, autoGenerateSkills) { }

    [DiceThrow(ThrowType._3D6)]
    public override int Strength { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    public override int Quickness { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    public override int Dexterity { get; set; }

    [DiceThrow(ThrowType._3D6)]
    public override int Stamina { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    public override int Health { get; set; }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(14)]
    public override int Beauty { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    public override int Intelligence { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    public override int Willpower { get; set; }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(12)]
    public override int Astral { get; set; }

    [DiceThrow(ThrowType._2D6)]
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

    public override int InitiateBaseValue => 6;

    public override int AttackBaseValue => 14;

    public override int DefenseBaseValue => 69;

    public override int AimBaseValue => 0;

    public override int CombatValueModifierPerLevel => 4;

    public override int BaseQualificationPoints => 8;

    public override int QualificationPointsModifier => 12;

    public override int PercentQualificationModifier => 0;

    public override int BaseLifePoints => 3;

    public override int BasePainTolerancePoints => 1;

    public override bool AddCombatModifierOnFirstLevel => false;

    public override bool AddPainToleranceOnFirstLevel => false;

    public override bool AddQualificationPointsOnFirstLevel => true;

    public override IRace[] AllowedRaces => [new Human(), new HalfElf(), new Amund(), new Jann(), new Wier(), new Draquon()];

    public override List<LevelRequirement> ExperienceLevels =>
    [
        new() { Level = 1,  MinExperience = 0,     MaxExperience = 150 },
        new() { Level = 2,  MinExperience = 151,   MaxExperience = 300 },
        new() { Level = 3,  MinExperience = 301,   MaxExperience = 600 },
        new() { Level = 4,  MinExperience = 601,   MaxExperience = 1000 },
        new() { Level = 5,  MinExperience = 1001,  MaxExperience = 2000 },
        new() { Level = 6,  MinExperience = 2001,  MaxExperience = 4000 },
        new() { Level = 7,  MinExperience = 4001,  MaxExperience = 9000 },
        new() { Level = 8,  MinExperience = 9001,  MaxExperience = 17000 },
        new() { Level = 9,  MinExperience = 17001, MaxExperience = 38500 },
        new() { Level = 10, MinExperience = 38501, MaxExperience = 58500 },
        new() { Level = 11, MinExperience = 58501, MaxExperience = 78500 },
        new() { Level = 12, MinExperience = 78501, MaxExperience = 108500 }
    ];

    public override ulong ExpPerLevelAfter12 => 31500;
    
    public override QualificationList Qualifications => BuildQualifications(
    [
        new WeaponUse(),
        new WeaponThrowing(),
        new PsiPyarron(QualificationLevel.Master),
        new LanguageLore(Language.Pyarronian, 3),
        new LanguageLore(3),
        new Herbalism(),
        new ReadingAndWriting(),
        new PoisoningAndNeutralization(),
        new Healing(),
        new SexualCulture()
    ]);

    public override QualificationList FutureQualifications => BuildQualifications(
    [
        new PoisoningAndNeutralization(QualificationLevel.Master, 4),
        new Herbalism(QualificationLevel.Master, 5)
    ]);

    public override PercentQualificationList PercentQualifications => [];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new Witchcraft()
    ];

    [DiceThrow(ThrowType._1D6)]
    public override int GetPainToleranceModifier() => DiceThrow._1D6();
}
