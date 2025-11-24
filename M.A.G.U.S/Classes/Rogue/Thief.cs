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

    public Thief(byte level) : base(level) { }

    [DiceThrow(ThrowType._3K6_2_Times)]
    public override sbyte Strength => DiceThrow._3K6_2_Times();

    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(8)]
    [SpecialTraining]
    public override sbyte Quickness => DiceThrow._1K10_Plus_8_Plus_SpecialTraining();

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(12)]
    [SpecialTraining]
    public override sbyte Dexterity => DiceThrow._1K6_Plus_12_Plus_SpecialTraining();

    [DiceThrow(ThrowType._3K6_2_Times)]
    public override sbyte Stamina => DiceThrow._3K6_2_Times();

    [DiceThrow(ThrowType._3K6_2_Times)]
    public override sbyte Health => DiceThrow._3K6_2_Times();

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(6)]
    public override sbyte Beauty => DiceThrow._2K6_Plus_6();

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(6)]
    public override sbyte Intelligence => DiceThrow._2K6_Plus_6();

    [DiceThrow(ThrowType._3K6)]
    public override sbyte Willpower => DiceThrow._3K6();

    [DiceThrow(ThrowType._3K6_2_Times)]
    public override sbyte Astral => DiceThrow._3K6_2_Times();

    [DiceThrow(ThrowType._1K10)]
    public override byte Gold => (byte)DiceThrow._1K10();

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(8)]
    public override sbyte Bravery => (sbyte)(DiceThrow._2K6() + 8);

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(8)]
    public override sbyte Erudition => (sbyte)(DiceThrow._2K6() + 8);

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(12)]
    public override sbyte Detection => (sbyte)(DiceThrow._1K6() + 12);

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

    public override QualificationList Qualifications =>
    [
        new WeaponUse(),
        new WeaponUse(),
        new WeaponThrowing(),
        new LanguageLore(3),
        new LanguageLore(2),
        new LanguageLore(2),
        new Appraisal(),
        new TavernBrawling()
    ];

    public override QualificationList FutureQualifications =>
    [
        new EscapeBonds(level: 2),
        new Knotting(level: 3),
        new Backstab(level: 3),
        new TavernBrawling(QualificationLevel.Master, 4),
        new WeaponThrowing(QualificationLevel.Master, 5)
    ];

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
