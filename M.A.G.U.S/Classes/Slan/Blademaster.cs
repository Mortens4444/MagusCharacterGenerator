using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.FightMode;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Combat;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Percentages;
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Classes.Slan;

public class Blademaster : Class, IClass, IJustFight
{
    public Blademaster() : base(1) { }

    public Blademaster(byte level) : base(level) { }

    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(8)]
    public override sbyte Strength => DiceThrow._1K10_Plus_8();

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(12)]
    [SpecialTraining]
    public override sbyte Quickness => DiceThrow._1K6_Plus_12_Plus_SpecialTraining();

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(14)]
    public override sbyte Dexterity => DiceThrow._1K6_Plus_14();

    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(8)]
    public override sbyte Stamina => DiceThrow._1K10_Plus_8();

    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(8)]
    public override sbyte Health => DiceThrow._1K10_Plus_8();

    [DiceThrow(ThrowType._3K6_2_Times)]
    public override sbyte Beauty => DiceThrow._3K6_2_Times();

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(6)]
    public override sbyte Intelligence => DiceThrow._2K6_Plus_6();

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(12)]
    public override sbyte Willpower => DiceThrow._1K6_Plus_12();

    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(8)]
    public override sbyte Astral => DiceThrow._1K10_Plus_8();

    [DiceThrow(ThrowType._1K6)]
    public override byte Gold => (byte)DiceThrow._1K6();

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(8)]
    public override sbyte Bravery => (sbyte)(DiceThrow._2K6() + 8);

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(8)]
    public override sbyte Erudition => (sbyte)(DiceThrow._2K6() + 8);

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(12)]
    public override sbyte Detection => (sbyte)(DiceThrow._1K6() + 12);

    public override byte InitiatingBaseValue => 10;

    public override byte AttackingBaseValue => 20;

    public override byte DefendingBaseValue => 75;

    public override byte AimingBaseValue => 0;

    public override byte FightValueModifier => 8;

    public override byte BaseQualificationPoints => 4;

    public override byte QualificationPointsModifier => 5;

    public override byte PercentQualificationModifier => 18;

    public override byte BaseLifePoints => 4;

    public override byte BasePainTolerancePoints => 8;

    public override bool AddFightValueOnFirstLevel => true;

    public override bool AddPainToleranceOnFirstLevel => false;

    public override bool AddQualificationPointsOnFirstLevel => true;

    public override QualificationList Qualifications =>
    [
        new PsiSlanWay(),
        new WeaponUse(),
        new WeaponUse(),
        new WeaponUse(),
        new WeaponBreaking(),
        new Fistfight(),
        new Wrestling(),
        new BlindFighting(),
        new Leadership(),
        new Etiquette(),
        new Riding(),
        new Swimming(),
        new Running()
   ];

    public override QualificationList FutureQualifications =>
    [
        new Riding(QualificationLevel.Master, 3),
        new WeaponBreaking(QualificationLevel.Master, 4),
        new BlindFighting(QualificationLevel.Master, 5),
        new WeaponUse(QualificationLevel.Master, 5)
    ];

    public override List<PercentQualification> PercentQualifications =>
    [
        new Climbing(10),
        new Falling(20),
        new Jumping(10)
    ];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new SlanDodgeAgainstRangedAttacks(),
        new SwordFighterMagicSword()
    ];

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(5)]
    public override byte GetPainToleranceModifier() => (byte)(DiceThrow._1K6() + 5);
}
