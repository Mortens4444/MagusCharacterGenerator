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
using M.A.G.U.S.Qualifications.Percentages;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Qualifications.Specialities;
using M.A.G.U.S.Qualifications.Underworld;
using M.A.G.U.S.Races;

namespace M.A.G.U.S.Classes.Rogue;

public class Bard : Class, IClass, IJustFight
{
    public Bard() : base(1) { }

    public Bard(int level) : base(level)
    {
        GenerateSkills();
    }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    public override int Strength { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    [SpecialTraining]
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

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(12)]
    [SpecialTraining]
    public override int Beauty { get; set; }

    [DiceThrow(ThrowType._1D10_2_Times)]
    [DiceThrowModifier(8)]
    public override int Intelligence { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    public override int Willpower { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    public override int Astral { get; set; }

    [DiceThrow(ThrowType._1D10)]
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

    public override int InitiateBaseValue => 10;

    public override int AttackBaseValue => 20;

    public override int DefenseBaseValue => 75;

    public override int AimBaseValue => 10;

    public override int CombatValueModifierPerLevel => 9;

    public override int BaseQualificationPoints => 4;

    public override int QualificationPointsModifier => 6;

    public override int PercentQualificationModifier => 45;

    public override int BaseLifePoints => 5;

    public override int BasePainTolerancePoints => 6;

    public override bool AddCombatModifierOnFirstLevel => false;

    public override bool AddPainToleranceOnFirstLevel => false;

    public override bool AddQualificationPointsOnFirstLevel => true;

    public override IRace[] AllowedRaces => [new Human(), new Elf(), new HalfElf(), new Amund(), new Jann(), new Feenhar(), new Dahr()];

    public override List<LevelRequirement> ExperienceLevels =>
    [
        new() { Level = 1,  MinExperience = 0,     MaxExperience = 170 },
        new() { Level = 2,  MinExperience = 171,   MaxExperience = 350 },
        new() { Level = 3,  MinExperience = 351,   MaxExperience = 1000 },
        new() { Level = 4,  MinExperience = 1001,  MaxExperience = 2200 },
        new() { Level = 5,  MinExperience = 2201,  MaxExperience = 4400 },
        new() { Level = 6,  MinExperience = 4401,  MaxExperience = 7500 },
        new() { Level = 7,  MinExperience = 7501,  MaxExperience = 15000 },
        new() { Level = 8,  MinExperience = 15001, MaxExperience = 30000 },
        new() { Level = 9,  MinExperience = 30001, MaxExperience = 55000 },
        new() { Level = 10, MinExperience = 55001, MaxExperience = 75000 },
        new() { Level = 11, MinExperience = 75001, MaxExperience = 95000 },
        new() { Level = 12, MinExperience = 95001, MaxExperience = 145000 }
    ];

    public override int ExpPerLevelAfter12 => 40000;
    
    public override QualificationList Qualifications => BuildQualifications(
    [
        new WeaponUse(),
        new WeaponUse(),
        new WeaponUse(),
        new WeaponUse(),
        new PsiPyarron(),
        new LanguageLore(Language.Pyarronian, 5),
        new LanguageLore(Language.Shadonian, 4),
        new LanguageLore(Language.Toronian, 3),
        new LanguageLore(Language.Erven, 2),
        new LanguageLore(Language.Doranian, 2),
        new ReadingAndWriting(),
        new LegendLore(QualificationLevel.Master),
        new Etiquette(),
        new Riding(),
        new SexualCulture(),
        new SingingAndMakingMusic(),
        new Onomatopoeia(),
        new CardSharping()
    ]);

    public override QualificationList FutureQualifications => BuildQualifications(
    [
        new Appraisal(level: 2),
        new Juggling(level: 2),
        new TavernBrawling(level: 2),
        new Fistfight(level: 3),
        new Knotting(level: 3),
        new Dancing(level: 3),
        new TavernBrawling(QualificationLevel.Master, 4),
        new WeaponThrowing(QualificationLevel.Master, 4),
        new EscapeBonds(level: 4),
        new Etiquette(QualificationLevel.Master, 4),
        new CardSharping(QualificationLevel.Master, 5),
        new PsiPyarron(QualificationLevel.Master, 5),
        new Backstab(level: 6),
        new SexualCulture(QualificationLevel.Master, 7),
        new Onomatopoeia(QualificationLevel.Master, 8)
    ]);

    public override PercentQualificationList PercentQualifications =>
    [
        new Climbing(25),
        new Falling(5),
        new Jumping(10),
        new LockPicking(25),
        new Sneaking(20),
        new Hiding(10),
        new TightropeWalking(5),
        new PickPocketing(5),
        new TrapDetection(10),
        new SecretDoorSearch(5),
    ];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new BardDetectMagicalObjects(),
        new BardicMagic()
    ];

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(3)]
    public override int GetPainToleranceModifier() => DiceThrow._1D6() + 3;
}
