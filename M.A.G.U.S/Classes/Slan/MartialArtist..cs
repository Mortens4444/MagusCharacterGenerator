using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.FightMode;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Battle;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Percentages;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Classes.Slan;

public class MartialArtist(byte level = 1) : Class(level), IClass, IJustFight
{
    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(8)]
    public override short Strength => DiceThrow._1K10_Plus_8();

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(14)]
    public override short Speed => DiceThrow._1K6_Plus_14();

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(12)]
    public override short Dexterity => DiceThrow._1K6_Plus_12();

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(12)]
    public override short Stamina => DiceThrow._1K6_Plus_12();

    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(10)]
    public override short Health => DiceThrow._1K10_Plus_10();

    [DiceThrow(ThrowType._3K6_2_Times)]
    public override short Beauty => DiceThrow._3K6_2_Times();

    [DiceThrow(ThrowType._3K6_2_Times)]
    public override short Intelligence => DiceThrow._3K6_2_Times();

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(12)]
    public override short WillPower => DiceThrow._1K6_Plus_12();

    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(8)]
    public override short Astral => DiceThrow._1K10_Plus_8();

    [DiceThrow(ThrowType._1K3)]
    public override short Gold => DiceThrow._1K3();

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(8)]
    public override byte Bravery => (byte)(DiceThrow._2K6() + 8);

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(8)]
    public override byte Erudition => (byte)(DiceThrow._2K6() + 8);

    public override byte InitiatingBaseValue => 10;

    public override byte AttackingBaseValue => 20;

    public override byte DefendingBaseValue => 75;

    public override byte AimingBaseValue => 0;

    public override byte FightValueModifier => 8;

    public override byte BaseQualificationPoints => 4;

    public override byte QualificationPointsModifier => 5;

    public override byte PercentQualificationModifier => 22;

    public override byte BaseLifePoints => 4;

    public override byte BasePainTolerancePoints => 8;

    public override bool AddFightValueOnFirstLevel => true;

    public override bool AddPainToleranceOnFirstLevel => false;

    public override bool AddQualificationPointsOnFirstLevel => true;

    public override QualificationList Qualifications =>
    [
        new PsiSlanWay(),
        new WeaponUsage(),
        new WeaponUsage(),
        new WeaponUsage(),
        new WeaponUsage(),
        new WeaponUsage(),
        new WeaponUsage(),
        new WeaponUsage(),
        new WeaponUsage(),
        new WeaponUsage(),
        new WeaponUsage(),
        new WeaponThrowing(),
        new WeaponThrowing(),
        new WeaponThrowing(),
        new WeaponThrowing(),
        new WeaponBreaking(),
        new Riding(),
        new Swimming(),
        new Running(),
        new BlindFighting()
   ];

    public override QualificationList FutureQualifications =>
    [
        new WoundHealing(level: 2),
        new WeaponBreaking(QualificationLevel.Master, 4),
        new BlindFighting(QualificationLevel.Master, 5),
        new WoundHealing(QualificationLevel.Master, 6)
    ];

    public override List<PercentQualification> PercentQualifications =>
    [
        new Climbing(20),
        new Falling(35),
        new Jumping(30)
    ];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new SlanDodgeFromRangedAttacks(),
        new BareHandFighterRunning(),
        new BareHandFighterMagicHand()
    ];

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(5)]
    public override byte GetPainToleranceModifier() => (byte)(DiceThrow._1K6() + 5);

    public override string ClassName => "Martial Artist";
}
