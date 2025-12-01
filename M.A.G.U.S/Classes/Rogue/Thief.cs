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

    public Thief(byte level) : base(level)
    {
        GenerateSkills();
    }

    [DiceThrow(ThrowType._3K6_2_Times)]
    public override sbyte Strength { get; set; }

    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(8)]
    [SpecialTraining]
    public override sbyte Quickness { get; set; }

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(12)]
    [SpecialTraining]
    public override sbyte Dexterity { get; set; }

    [DiceThrow(ThrowType._3K6_2_Times)]
    public override sbyte Stamina { get; set; }

    [DiceThrow(ThrowType._3K6_2_Times)]
    public override sbyte Health { get; set; }

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(6)]
    public override sbyte Beauty { get; set; }

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(6)]
    public override sbyte Intelligence { get; set; }

    [DiceThrow(ThrowType._3K6)]
    public override sbyte Willpower { get; set; }

    [DiceThrow(ThrowType._3K6_2_Times)]
    public override sbyte Astral { get; set; }

    [DiceThrow(ThrowType._1K10)]
    public override byte Gold { get; set; }

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(8)]
    public override sbyte Bravery { get; set; }

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(8)]
    public override sbyte Erudition { get; set; }

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(12)]
    public override sbyte Detection { get; set; }

    public override byte InitiatingBaseValue => 8;

    public override byte AttackingBaseValue => 17;

    public override byte DefendingBaseValue => 72;

    public override byte AimingBaseValue => 10;

    public override byte FightValueModifier => 6;

    public override byte BaseQualificationPoints => 8;

    public override byte QualificationPointsModifier => 10;

    public override byte PercentQualificationModifier => 62;

    public override byte BaseLifePoints => 4;

    public override byte BasePainTolerancePoints => 5;

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

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(3)]
    public override byte GetPainToleranceModifier() => (byte)(DiceThrow._1K6() + 3);
}
