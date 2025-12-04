using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.FightMode;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Combat;
using M.A.G.U.S.Qualifications.Percentages;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Classes.Fighter;

public class Gladiator : Class, IClass, IJustFight
{
    public Gladiator() : base(1) { }

    public Gladiator(byte level) : base(level)
    {
        GenerateSkills();
    }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(12)]
    [SpecialTraining]
    public override sbyte Strength { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    [SpecialTraining]
    public override sbyte Quickness { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    [SpecialTraining]
    public override sbyte Dexterity { get; set; }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(12)]
    [SpecialTraining]
    public override sbyte Stamina { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(10)]
    public override sbyte Health { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    public override sbyte Beauty { get; set; }

    [DiceThrow(ThrowType._3D6)]
    public override sbyte Intelligence { get; set; }

    [DiceThrow(ThrowType._3D6)]
    public override sbyte Willpower { get; set; }

    [DiceThrow(ThrowType._3D6)]
    public override sbyte Astral { get; set; }

    [DiceThrow(ThrowType._2D6)]
    public override byte Gold { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(8)]
    public override sbyte Bravery { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(8)]
    public override sbyte Erudition { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    public override sbyte Detection { get; set; }

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

    public override QualificationList Qualifications => BuildQualifications(
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
    ]);

    public override QualificationList FutureQualifications => BuildQualifications(
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
    ]);

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

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(5)]
    public override byte GetPainToleranceModifier() => (byte)(DiceThrow._1D6() + 5);
}
