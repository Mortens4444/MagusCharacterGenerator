using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.FightMode;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Combat;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Qualifications.Scientific.Psi;

namespace M.A.G.U.S.Classes.Fighter;

public class Knight(byte level = 1) : Class(level), IClass, IHateRangedWeapons
{
    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(12)]
    [SpecialTraining]
    public override sbyte Strength => DiceThrow._1K6_Plus_12_Plus_SpecialTraining();

    [DiceThrow(ThrowType._3K6_2_Times)]
    public override sbyte Speed => DiceThrow._3K6_2_Times();

    [DiceThrow(ThrowType._3K6_2_Times)]
    public override sbyte Dexterity => DiceThrow._3K6_2_Times();

    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(8)]
    [SpecialTraining]
    public override sbyte Stamina => DiceThrow._1K10_Plus_8_Plus_SpecialTraining();

    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(10)]
    public override sbyte Health => DiceThrow._1K10_Plus_10();

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(6)]
    [SpecialTraining]
    public override sbyte Beauty => DiceThrow._2K6_Plus_6_Plus_SpecialTraining();

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(6)]
    public override sbyte Intelligence => DiceThrow._2K6_Plus_6();

    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(8)]
    public override sbyte Willpower => DiceThrow._1K10_Plus_8();

    [DiceThrow(ThrowType._3K6_2_Times)]
    public override sbyte Astral => DiceThrow._3K6_2_Times();

    [DiceThrow(ThrowType._2K6)]
    public override byte Gold => (byte)DiceThrow._2K6();

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(8)]
    public override sbyte Bravery => (sbyte)(DiceThrow._2K6() + 8);

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(8)]
    public override sbyte Erudition => (sbyte)(DiceThrow._2K6() + 8);

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(6)]
    public override sbyte Detection => (sbyte)(DiceThrow._2K6() + 6);

    public override byte InitiatingBaseValue => 5;

    public override byte AttackingBaseValue => 20;

    public override byte DefendingBaseValue => 75;

    public override byte AimingBaseValue => throw new InvalidOperationException();

    public override byte FightValueModifier => 12;

    public override byte BaseQualificationPoints => 4;

    public override byte QualificationPointsModifier => 7;

    public override byte PercentQualificationModifier => 0;

    public override byte BaseLifePoints => 7;

    public override byte BasePainTolerancePoints => 6;

    public override bool AddFightValueOnFirstLevel => false;

    public override bool AddPainToleranceOnFirstLevel => true;

    public override bool AddQualificationPointsOnFirstLevel => true;

    public override QualificationList Qualifications =>
    [
        new HeavyArmorWearing(),
        new ShieldUse(),
        new WeaponUse(),
        new WeaponUse(),
        new WeaponUse(),
        new WeaponUse(),
        new WeaponUse(),
        new WeaponLore(),
        new Leadership(),
        new Etiquette(),
        new Riding(QualificationLevel.Master),
        new LanguageLore(4),
        new LanguageLore(2),
        new LanguageLore(2),
        new LanguageLore(2),
        new ReadingAndWriting(),
        new Heraldry()
    ];

    public override QualificationList FutureQualifications =>
    [
        new Heraldry(QualificationLevel.Master, 3),
        new ShieldUse(QualificationLevel.Master, 4),
        new PsiPyarron(level: 4),
        new Healing(level: 4),
        new WeaponUse(QualificationLevel.Master, 5),
        new HeavyArmorWearing(QualificationLevel.Master, 8),
        new Leadership(QualificationLevel.Master, 9),
        new PsiPyarron(QualificationLevel.Master, 12)
    ];

    public override List<PercentQualification> PercentQualifications => [];

    public override SpecialQualificationList SpecialQualifications => [];

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(5)]
    public override byte GetPainToleranceModifier() => (byte)(DiceThrow._1K6() + 5);
}
