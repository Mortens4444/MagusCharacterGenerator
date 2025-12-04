using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.FightMode;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Combat;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Magic;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Classes.Believer.GodsOfPyarron;

/// <summary>
/// Nastar = Krad
/// https://nemaakos.files.wordpress.com/2014/10/nastar2.pdf
/// </summary>
public class NastarPriest : Class, IClass, ILikeMagic
{
    public NastarPriest() : base(1) { }

    public NastarPriest(byte level) : base(level)
    {
        GenerateSkills();
    }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    public override sbyte Strength { get; set; }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override sbyte Quickness { get; set; }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override sbyte Dexterity { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    public override sbyte Stamina { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    public override sbyte Health { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(10)]
    public override sbyte Beauty { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    public override sbyte Intelligence { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    [SpecialTraining]
    public override sbyte Willpower { get; set; }

    [DiceThrow(ThrowType._1D6)]
    public override byte Gold { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(8)]
    public override sbyte Bravery { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(8)]
    public override sbyte Erudition { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    public override sbyte Detection { get; set; }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(12)]
    [SpecialTraining]
    public override sbyte Astral { get; set; }

    public override byte InitiatingBaseValue => 4;

    public override byte AttackingBaseValue => 16;

    public override byte DefendingBaseValue => 72;

    public override byte AimingBaseValue => 0;

    public override byte FightValueModifier => 7;

    public override byte BaseQualificationPoints => 6;

    public override byte QualificationPointsModifier => 10;

    public override byte PercentQualificationModifier => 0;

    public override byte BaseLifePoints => 6;

    public override byte BasePainTolerancePoints => 6;

    public override bool AddFightValueOnFirstLevel => false;

    public override bool AddPainToleranceOnFirstLevel => false;

    public override bool AddQualificationPointsOnFirstLevel => true;

    public override QualificationList Qualifications => BuildQualifications(
    [
        new WeaponUse(),
        new PsiPyarron(QualificationLevel.Master),
        new LanguageLore(5),
        new LanguageLore(5),
        new LanguageLore(5),
        new Etiquette(),
        new ReadingAndWriting(),
        new Herbalism(),
        new ReligionLore(QualificationLevel.Master),
        new HistoryLore(),
        new LegendLore(),
        new Craft(Profession.Jeweler),

		// TODO
		//new Emberismeret()
		//new Erkölcs(),
		//new Helyismeret 60%
		//new Kultúra (Saját)
		//new ÉkszerészSzakma
    ]);

    public override QualificationList FutureQualifications => BuildQualifications(
    [
        new LanguageLore(2, 3),
        new LanguageLore(2, 3),
        new Healing(level: 3),
        new ReadingAndWriting(QualificationLevel.Master, 4),
        new LanguageLore(6, 4),
		//new Emberismeret MF 5
		new Healing(QualificationLevel.Master, 5),
        new LegendLore(QualificationLevel.Master, 6),
        new Craft(Profession.Jeweler, QualificationLevel.Master, 8),
		//new DrágakőMágia(QualificationLevel.Master, 12)
	]);

    public override List<PercentQualification> PercentQualifications => [];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new PsiSiegeKyrDisciplineUsage(),
        new ClericalMagic()
    ];

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(2)]
    public override byte GetPainToleranceModifier() => (byte)(DiceThrow._1D6() + 2);

    public override string Name => "Priest of Nastar";
}
