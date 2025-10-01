using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.FightMode;
using M.A.G.U.S.GameSystem.Languages;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Combat;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Magic;
using M.A.G.U.S.Qualifications.Percentages;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Qualifications.Underworld;

namespace M.A.G.U.S.Classes.Sorcerer;

/// <summary>
/// https://www.kalandozok.hu/magus/kalandozok/jatszhatokasztok/magiahasznalo/boszorkanymester/kraniboszorkanymester(mg)kalandozok.pdf
/// </summary>
public class KranichWarlock(byte level = 1) : Class(level), IClass, ILikeMagic
{
    [DiceThrow(ThrowType._3K6_2_Times)]
    public override short Strength => DiceThrow._3K6_2_Times();

    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(8)]
    public override short Speed => DiceThrow._1K10_Plus_8();

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(12)]
    [SpecialTraining]
    public override short Dexterity => DiceThrow._1K6_Plus_12_Plus_SpecialTraining();

    [DiceThrow(ThrowType._3K6_2_Times)]
    public override short Stamina => DiceThrow._3K6_2_Times();

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(3)]
    public override short Health => DiceThrow._2K6_Plus_3();

    [DiceThrow(ThrowType._3K6)]
    public override short Beauty => DiceThrow._3K6();

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(6)]
    public override short Intelligence => DiceThrow._2K6_Plus_6();

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(12)]
    public override short Willpower => DiceThrow._1K6_Plus_12();

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(12)]
    public override short Astral => DiceThrow._1K6_Plus_12();

    [DiceThrow(ThrowType._3K6)]
    public override short Gold => DiceThrow._3K6();

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(8)]
    public override byte Bravery => (byte)(DiceThrow._2K6() + 8);

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(8)]
    public override byte Erudition => (byte)(DiceThrow._2K6() + 8);

    public override byte InitiatingBaseValue => 7;

    public override byte AttackingBaseValue => 17;

    public override byte DefendingBaseValue => 72;

    public override byte AimingBaseValue => 5;

    public override byte FightValueModifier => 7;

    public override byte BaseQualificationPoints => 4;

    public override byte QualificationPointsModifier => 6;

    public override byte PercentQualificationModifier => 10;

    public override byte BaseLifePoints => 4;

    public override byte BasePainTolerancePoints => 3;

    public override bool AddFightValueOnFirstLevel => false;

    public override bool AddPainToleranceOnFirstLevel => false;

    public override bool AddQualificationPointsOnFirstLevel => true;

    public override QualificationList Qualifications =>
    [
        new WeaponUse(),
            new WeaponUse(),
            new WeaponThrowing(),
            new PsiKranic(QualificationLevel.Master),
            new ReadingAndWriting(),
            new PoisoningAndNeutralization(),
            new CamouflageOrDisguise(),
            new LanguageLore(Language.Kranich, 3),
            new Alchemy(),
        new AncientTongueLore(AntientLanguage.Aquir),
        new Etiquette(), //Kranich

		//new Cluture(QualificationLevel.Master) // Order
		//new Helyismeret 60%
   ];

    public override QualificationList FutureQualifications =>
    [
        new Craft(Profession.TattoMaker, level: 2),
        new ReligionLore(level: 2),
            new Herbalism(level: 3),
        new Alchemy(QualificationLevel.Master, 3),
        new Etiquette(QualificationLevel.Master, 4), //Kranich
            new PoisoningAndNeutralization(QualificationLevel.Master, 4),
        new Craft(Profession.TattoMaker, QualificationLevel.Master, 5),
        new Backstab(level: 5),
        new Herbalism(QualificationLevel.Master, 6),
        new AncientTongueLore(AntientLanguage.Aquir, QualificationLevel.Master, 6),
        new RunicMagic(level: 7),
        new Demonology(level: 8)
];

    public override List<PercentQualification> PercentQualifications =>
    [
        new Sneaking(15),
            new Hiding(10)
    ];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new Warlockry()
    ];

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(1)]
    public override byte GetPainToleranceModifier() => (byte)(DiceThrow._1K6() + 1);

    public override string Name => "Krani Mage";
}
