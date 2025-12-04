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

    public Blademaster(byte level) : base(level)
    {
        GenerateSkills();
    }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    public override sbyte Strength { get; set; }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(12)]
    [SpecialTraining]
    public override sbyte Quickness { get; set; }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(14)]
    public override sbyte Dexterity { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    public override sbyte Stamina { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    public override sbyte Health { get; set; }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override sbyte Beauty { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    public override sbyte Intelligence { get; set; }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(12)]
    public override sbyte Willpower { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    public override sbyte Astral { get; set; }

    [DiceThrow(ThrowType._1D6)]
    public override byte Gold { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(8)]
    public override sbyte Bravery { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(8)]
    public override sbyte Erudition { get; set; }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(12)]
    public override sbyte Detection { get; set; }

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

    public override QualificationList Qualifications => BuildQualifications(
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
    ]);

    public override QualificationList FutureQualifications => BuildQualifications(
    [
        new Riding(QualificationLevel.Master, 3),
        new WeaponBreaking(QualificationLevel.Master, 4),
        new BlindFighting(QualificationLevel.Master, 5),
        new WeaponUse(QualificationLevel.Master, 5)
    ]);

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

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(5)]
    public override byte GetPainToleranceModifier() => (byte)(DiceThrow._1D6() + 5);
}
