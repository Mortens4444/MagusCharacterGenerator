using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.FightMode;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Battle;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Magic;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Qualifications.Scientific.Psi;

namespace M.A.G.U.S.Classes.Sorcerer;

public class Witch(byte level = 1) : Class(level), IClass, ILikeMagic
{
    [DiceThrow(ThrowType._3K6)]
    public override short Strength => DiceThrow._3K6();

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(6)]
    public override short Speed => DiceThrow._2K6_Plus_6();

    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(8)]
    public override short Dexterity => DiceThrow._1K10_Plus_8();

    [DiceThrow(ThrowType._3K6)]
    public override short Stamina => DiceThrow._3K6();

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(6)]
    public override short Health => DiceThrow._2K6_Plus_6();

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(14)]
    public override short Beauty => DiceThrow._1K6_Plus_14();

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(6)]
    public override short Intelligence => DiceThrow._2K6_Plus_6();

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(6)]
    public override short Willpower => DiceThrow._2K6_Plus_6();

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(12)]
    public override short Astral => DiceThrow._1K6_Plus_12_Plus_SpecialTraining();

    [DiceThrow(ThrowType._2K6)]
    public override short Gold => DiceThrow._2K6();

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(8)]
    public override byte Bravery => (byte)(DiceThrow._2K6() + 8);

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(8)]
    public override byte Erudition => (byte)(DiceThrow._2K6() + 8);

    public override byte InitiatingBaseValue => 6;

    public override byte AttackingBaseValue => 14;

    public override byte DefendingBaseValue => 69;

    public override byte AimingBaseValue => 0;

    public override byte FightValueModifier => 4;

    public override byte BaseQualificationPoints => 8;

    public override byte QualificationPointsModifier => 12;

    public override byte PercentQualificationModifier => 0;

    public override byte BaseLifePoints => 3;

    public override byte BasePainTolerancePoints => 1;

    public override bool AddFightValueOnFirstLevel => false;

    public override bool AddPainToleranceOnFirstLevel => false;

    public override bool AddQualificationPointsOnFirstLevel => true;

    public override QualificationList Qualifications =>
    [
        new WeaponUse(),
        new WeaponThrowing(),
        new PsiPyarron(QualificationLevel.Master),
        new LanguageLore(3),
        new LanguageLore(3),
        new Herbalism(),
        new ReadingAndWriting(),
        new PoisoningAndNeutralization(),
        new Healing(),
        new SexualCulture()
   ];

    public override QualificationList FutureQualifications =>
    [
        new PoisoningAndNeutralization(QualificationLevel.Master, 4),
        new Herbalism(QualificationLevel.Master, 5)
    ];

    public override List<PercentQualification> PercentQualifications => [];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new Witchcraft()
    ];

    [DiceThrow(ThrowType._1K6)]
    public override byte GetPainToleranceModifier() => (byte)DiceThrow._1K6();
}
