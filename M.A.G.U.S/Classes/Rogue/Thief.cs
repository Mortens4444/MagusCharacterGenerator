using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.FightMode;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Combat;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Percentages;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Qualifications.Specialities;
using M.A.G.U.S.Qualifications.Underworld;

namespace M.A.G.U.S.Classes.Rogue;

public class Thief : Class, IClass, IJustFight
{
    public Thief() : base(1) { }

    public Thief(int level) : base(level)
    {
        GenerateSkills();
    }

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

    public override int InitiatingBaseValue => 8;

    public override int AttackingBaseValue => 17;

    public override int DefendingBaseValue => 72;

    public override int AimingBaseValue => 10;

    public override int FightValueModifier => 6;

    public override int BaseQualificationPoints => 8;

    public override int QualificationPointsModifier => 10;

    public override int PercentQualificationModifier => 62;

    public override int BaseLifePoints => 4;

    public override int BasePainTolerancePoints => 5;

    public override bool AddFightValueOnFirstLevel => false;

    public override bool AddPainToleranceOnFirstLevel => false;

    public override bool AddQualificationPointsOnFirstLevel => true;

    public override QualificationList Qualifications => BuildQualifications(
    [
        new WeaponUse(),
        new WeaponUse(),
        new WeaponThrowing(),
        new LanguageLore(3),
        new LanguageLore(2),
        new LanguageLore(2),
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

    public override List<PercentQualification> PercentQualifications =>
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
        new ThiefInitiatingValueIncreasing()
    ];

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(3)]
    public override int GetPainToleranceModifier() => DiceThrow._1D6() + 3;
}
