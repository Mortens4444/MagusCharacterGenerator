using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.FightMode;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Battle;
using M.A.G.U.S.Qualifications.Percentages;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Classes.Fighter;

public class Gladiator(byte level = 1) : Class(level), IClass, IJustFight
{
    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(12)]
    [SpecialTraining]
    public override short Strength => DiceThrow._1K6_Plus_12_Plus_SpecialTraining();

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(6)]
    [SpecialTraining]
    public override short Speed => DiceThrow._2K6_Plus_6_Plus_SpecialTraining();

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(6)]
    [SpecialTraining]
    public override short Dexterity => DiceThrow._2K6_Plus_6_Plus_SpecialTraining();

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(12)]
    [SpecialTraining]
    public override short Stamina => DiceThrow._1K6_Plus_12_Plus_SpecialTraining();

    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(10)]
    public override short Health => DiceThrow._1K10_Plus_10();

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(6)]
    public override short Beauty => DiceThrow._2K6_Plus_6();

    [DiceThrow(ThrowType._3K6)]
    public override short Intelligence => DiceThrow._3K6();

    [DiceThrow(ThrowType._3K6)]
    public override short Willpower => DiceThrow._3K6();

    [DiceThrow(ThrowType._3K6)]
    public override short Astral => DiceThrow._3K6();

    [DiceThrow(ThrowType._2K6)]
    public override short Gold => DiceThrow._2K6();

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(8)]
    public override byte Bravery => (byte)(DiceThrow._2K6() + 8);

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(8)]
    public override byte Erudition => (byte)(DiceThrow._2K6() + 8);

    public override byte InitiatingBaseValue => 9;

    public override byte AttackingBaseValue => 20;

    public override byte DefendingBaseValue => 75;

    public override byte AimingBaseValue => 0;

    public override byte FightValueModifier => 12;

    public override byte BaseQualificationPoints => 3;

    public override byte QualificationPointsModifier => 6;

    public override byte PercentQualificationModifier => 0;

    public override byte BaseLifePoints => 8;

    public override byte BasePainTolerancePoints => 7;

    public override bool AddFightValueOnFirstLevel => false;

    public override bool AddPainToleranceOnFirstLevel => true;

    public override bool AddQualificationPointsOnFirstLevel => true;

    public override QualificationList Qualifications =>
    [
        new WeaponUse(),
        new WeaponUse(),
        new WeaponUse(),
        new WeaponUse(),
        new Wrestling(),
        new Fistfight(),
        new TwoHandedCombat(),
        new HeavyArmorWearing(),
        new ShieldUse(),
        new WeaponBreaking()
    ];

    public override QualificationList FutureQualifications =>
    [
        new WeaponUse(level: 2),
        new WeaponUse(level: 4),
        new WeaponUse(QualificationLevel.Master),
        new TwoHandedCombat(QualificationLevel.Master),
        new BlindFighting(level: 6),
        new WeaponUse(level: 7),
        new WeaponUse(level: 7),
        new ShieldUse(QualificationLevel.Master),
        new WeaponBreaking(QualificationLevel.Master)
    ];

    public override List<PercentQualification> PercentQualifications =>
    [
        new Falling(30),
        new Jumping(20)
    ];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new GladiatorFightAgainstOneEnemy(),
        new GladiatorFightInFrontOfAudience()
    ];

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(5)]
    public override byte GetPainToleranceModifier() => (byte)(DiceThrow._1K6() + 5);
}
