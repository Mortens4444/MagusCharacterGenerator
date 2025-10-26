using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.FightMode;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Combat;
using M.A.G.U.S.Qualifications.Magic;
using M.A.G.U.S.Qualifications.Percentages;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Qualifications.Underworld;

namespace M.A.G.U.S.Classes.Sorcerer;

public class Warlock(byte level = 1) : Class(level), IClass, ILikeMagic
{
    [DiceThrow(ThrowType._3K6_2_Times)]
    public override sbyte Strength => DiceThrow._3K6_2_Times();

    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(8)]
    public override sbyte Speed => DiceThrow._1K10_Plus_8();

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(12)]
    [SpecialTraining]
    public override sbyte Dexterity => DiceThrow._1K6_Plus_12_Plus_SpecialTraining();

    [DiceThrow(ThrowType._3K6_2_Times)]
    public override sbyte Stamina => DiceThrow._3K6_2_Times();

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(6)]
    public override sbyte Health => DiceThrow._2K6_Plus_6();

    [DiceThrow(ThrowType._3K6)]
    public override sbyte Beauty => DiceThrow._3K6();

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(6)]
    public override sbyte Intelligence => DiceThrow._2K6_Plus_6();

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(6)]
    public override sbyte Willpower => DiceThrow._2K6_Plus_6();

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(12)]
    public override sbyte Astral => DiceThrow._1K6_Plus_12();

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

    public override byte InitiatingBaseValue => 7;

    public override byte AttackingBaseValue => 17;

    public override byte DefendingBaseValue => 72;

    public override byte AimingBaseValue => 5;

    public override byte FightValueModifier => 7;

    public override byte BaseQualificationPoints => 7;

    public override byte QualificationPointsModifier => 8;

    public override byte PercentQualificationModifier => 15;

    public override byte BaseLifePoints => 3;

    public override byte BasePainTolerancePoints => 4;

    public override bool AddFightValueOnFirstLevel => false;

    public override bool AddPainToleranceOnFirstLevel => false;

    public override bool AddQualificationPointsOnFirstLevel => true;

    public override QualificationList Qualifications =>
    [
        new WeaponUse(),
        new WeaponUse(),
        new WeaponUse(),
        new WeaponThrowing(),
        new PsiPyarron(QualificationLevel.Master),
        new LanguageLore(3),
        new LanguageLore(3),
        new LanguageLore(2),
        new ReadingAndWriting(),
        new PoisoningAndNeutralization(),
        new CamouflageOrDisguise(),
        new Herbalism(),
   ];

    public override QualificationList FutureQualifications =>
    [
        new Backstab(level: 2),
        new PoisoningAndNeutralization(QualificationLevel.Master, 4),
        new Backstab(QualificationLevel.Master, 5),
        new Herbalism(QualificationLevel.Master, 6)
    ];

    public override List<PercentQualification> PercentQualifications =>
    [
        new Sneaking(15),
        new Hiding(15)
    ];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new Warlockry()
    ];

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(1)]
    public override byte GetPainToleranceModifier() => (byte)(DiceThrow._1K6() + 1);
}
