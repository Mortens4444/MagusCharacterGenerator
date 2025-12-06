using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.FightMode;
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

    public override int InitiatingBaseValue => 10;

    public override int AttackingBaseValue => 20;

    public override int DefendingBaseValue => 75;

    public override int AimingBaseValue => 10;

    public override int FightValueModifier => 9;

    public override int BaseQualificationPoints => 4;

    public override int QualificationPointsModifier => 6;

    public override int PercentQualificationModifier => 45;

    public override int BaseLifePoints => 5;

    public override int BasePainTolerancePoints => 6;

    public override bool AddFightValueOnFirstLevel => false;

    public override bool AddPainToleranceOnFirstLevel => false;

    public override bool AddQualificationPointsOnFirstLevel => true;

    public override QualificationList Qualifications => BuildQualifications(
    [
        new WeaponUse(),
        new WeaponUse(),
        new WeaponUse(),
        new WeaponUse(),
        new PsiPyarron(),
        new LanguageLore(5),
        new LanguageLore(4),
        new LanguageLore(3),
        new LanguageLore(2),
        new LanguageLore(2),
        new ReadingAndWriting(),
        new LegendLore(QualificationLevel.Master),
        new Etiquette(),
        new Riding(),
        new SexualCulture(),
        new SingingAndMakingMusic(),
        new Mimicry(),
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
        new Mimicry(QualificationLevel.Master, 8)
    ]);

    public override List<PercentQualification> PercentQualifications =>
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
