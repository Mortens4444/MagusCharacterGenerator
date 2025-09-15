using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.FightMode;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Battle;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Magic;
using M.A.G.U.S.Qualifications.Percentages;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Qualifications.Specialities;
using M.A.G.U.S.Qualifications.Underworld;

namespace M.A.G.U.S.Classes.Rogue;

public class Bard(byte level = 1) : Class(level), IClass, IJustFight
{
    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(8)]
    public override short Strength => DiceThrow._1K10_Plus_8();

    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(8)]
    [SpecialTraining]
    public override short Speed => DiceThrow._1K10_Plus_8_Plus_SpecialTraining();

    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(8)]
    public override short Dexterity => DiceThrow._1K10_Plus_8();

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(6)]
    public override short Stamina => DiceThrow._2K6_Plus_6();

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(6)]
    public override short Health => DiceThrow._2K6_Plus_6();

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(12)]
    [SpecialTraining]
    public override short Beauty => DiceThrow._1K6_Plus_12_Plus_SpecialTraining();

    [DiceThrow(ThrowType._1K10_2_Times)]
    [DiceThrowModifier(8)]
    public override short Intelligence => DiceThrow._1K10_Plus_8_2_Times();

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(6)]
    public override short WillPower => DiceThrow._2K6_Plus_6();

    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(8)]
    public override short Astral => DiceThrow._1K10_Plus_8();

    [DiceThrow(ThrowType._1K10)]
    public override short Gold => DiceThrow._1K10();

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(8)]
    public override byte Bravery => (byte)(DiceThrow._2K6() + 8);

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(8)]
    public override byte Erudition => (byte)(DiceThrow._2K6() + 8);

    public override byte InitiatingBaseValue => 10;

    public override byte AttackingBaseValue => 20;

    public override byte DefendingBaseValue => 75;

    public override byte AimingBaseValue => 10;

    public override byte FightValueModifier => 9;

    public override byte BaseQualificationPoints => 4;

    public override byte QualificationPointsModifier => 6;

    public override byte PercentQualificationModifier => 45;

    public override byte BaseLifePoints => 5;

    public override byte BasePainTolerancePoints => 6;

    public override bool AddFightValueOnFirstLevel => false;

    public override bool AddPainToleranceOnFirstLevel => false;

    public override bool AddQualificationPointsOnFirstLevel => true;

    public override QualificationList Qualifications =>
    [
        new WeaponUsage(),
        new WeaponUsage(),
        new WeaponUsage(),
        new WeaponUsage(),
        new PsiPyarron(),
        new LanguageKnowledge(5),
        new LanguageKnowledge(4),
        new LanguageKnowledge(3),
        new LanguageKnowledge(2),
        new LanguageKnowledge(2),
        new ReadingAndWriting(),
        new LegendKnowledge(QualificationLevel.Master),
        new Etiquette(),
        new Riding(),
        new SexualCulture(),
        new SingingAndMakingMusic(),
        new SoundImitation(),
        new CardSharper()
   ];

    public override QualificationList FutureQualifications =>
    [
        new ValueEstimation(level: 2),
        new Juggling(level: 2),
        new PubFighting(level: 2),
        new FistFighting(level: 3),
        new Knotting(level: 3),
        new Dancing(level: 3),
        new PubFighting(QualificationLevel.Master, 4),
        new WeaponThrowing(QualificationLevel.Master, 4),
        new FreeFromBondage(level: 4),
        new Etiquette(QualificationLevel.Master, 4),
        new CardSharper(QualificationLevel.Master, 5),
        new PsiPyarron(QualificationLevel.Master, 5),
        new Backstab(level: 6),
        new SexualCulture(QualificationLevel.Master, 7),
        new SoundImitation(QualificationLevel.Master, 8)
    ];

    public override List<PercentQualification> PercentQualifications =>
    [
        new Climbing(25),
        new Falling(5),
        new Jumping(10),
        new LockPicking(25),
        new Sneaking(20),
        new Stealth(10),
        new Tightrope(5),
        new PickPocketing(5),
        new TrapDetect(10),
        new SecretDoorSearching(5),
    ];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new BardDetectMagicalObjects(),
        new BardMagic()
    ];

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(3)]
    public override byte GetPainToleranceModifier() => (byte)(DiceThrow._1K6() + 3);
}
