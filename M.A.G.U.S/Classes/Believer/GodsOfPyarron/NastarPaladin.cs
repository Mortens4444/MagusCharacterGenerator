using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.FightMode;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Combat;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Magic;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Qualifications.Scientific.Psi;

namespace M.A.G.U.S.Classes.Believer.GodsOfPyarron;

public class NastarPaladin(byte level = 1) : Class(level), IClass, IHateRangedWeapons
{
    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(8)]
    [SpecialTraining]
    public override short Strength => DiceThrow._1K10_Plus_8_Plus_SpecialTraining();

    [DiceThrow(ThrowType._3K6_2_Times)]
    public override short Speed => DiceThrow._3K6_2_Times();

    [DiceThrow(ThrowType._3K6_2_Times)]
    public override short Dexterity => DiceThrow._3K6_2_Times();

    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(8)]
    public override short Stamina => DiceThrow._1K10_Plus_8();

    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(10)]
    public override short Health => DiceThrow._1K10_Plus_10();

    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(8)]
    public override short Beauty => DiceThrow._1K10_Plus_8();

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(6)]
    public override short Intelligence => DiceThrow._2K6_Plus_6();

    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(8)]
    public override short Willpower => DiceThrow._1K10_Plus_8();

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(12)]
    public override short Astral => DiceThrow._1K6_Plus_12();

    [DiceThrow(ThrowType._1K6)]
    public override short Gold => DiceThrow._1K6();

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(8)]
    public override byte Bravery => (byte)(DiceThrow._2K6() + 8);

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(8)]
    public override byte Erudition => (byte)(DiceThrow._2K6() + 8);

    public override byte InitiatingBaseValue => 5;

    public override byte AttackingBaseValue => 20;

    public override byte DefendingBaseValue => 75;

    public override byte AimingBaseValue => 0;

    public override byte FightValueModifier => 9;

    public override byte BaseQualificationPoints => 5;

    public override byte QualificationPointsModifier => 5;

    public override byte PercentQualificationModifier => 0;

    public override byte BaseLifePoints => 6;

    public override byte BasePainTolerancePoints => 7;

    public override bool AddFightValueOnFirstLevel => false;

    public override bool AddPainToleranceOnFirstLevel => false;

    public override bool AddQualificationPointsOnFirstLevel => true;

    public override QualificationList Qualifications =>
    [
        new WeaponUse(),
        new WeaponUse(),
        new WeaponUse(),
        new WeaponUse(),
        new PsiPyarron(QualificationLevel.Master),
        new LanguageLore(3),
        new LanguageLore(3),
        new LanguageLore(3),
        new Etiquette(),
        new HeavyArmorWearing(),
        new WeaponLore(),
        new Leadership(),
        new ReadingAndWriting(),
        new Heraldry(),
        new Riding(),
        new Healing(),
        new HistoryLore(),
        new ReligionLore()
        // new Erkölcs(QualificationLevel.Master)
        // new Helyismeret(60%)
        // new Kultúra(QualificationLevel.Master) Saját
    ];

    public override QualificationList FutureQualifications =>
    [
		// new HárítófegyverHasználat(level: 2)
		new Craft(Profession.Smith, level: 3),
        new HistoryLore(QualificationLevel.Master, 4),
        new Craft(Profession.Smith, QualificationLevel.Master, 6),
        new WeaponUse(QualificationLevel.Master, 8)
    ];

    public override List<PercentQualification> PercentQualifications => [];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new ClericalMagic()
    ];

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(5)]
    public override byte GetPainToleranceModifier() => (byte)(DiceThrow._1K6() + 5);

    public override string Name => "Paladin of Nastar";
}
