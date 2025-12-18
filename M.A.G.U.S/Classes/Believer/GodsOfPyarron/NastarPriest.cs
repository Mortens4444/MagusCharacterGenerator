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

    public NastarPriest(int level) : base(level)
    {
        GenerateSkills();
    }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    public override int Strength { get; set; }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override int Quickness { get; set; }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override int Dexterity { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    public override int Stamina { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    public override int Health { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(10)]
    public override int Beauty { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    public override int Intelligence { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    [SpecialTraining]
    public override int Willpower { get; set; }

    [DiceThrow(ThrowType._1D6)]
    public override int Gold { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(8)]
    public override int Bravery { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(8)]
    public override int Erudition { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    public override int Detection { get; set; }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(12)]
    [SpecialTraining]
    public override int Astral { get; set; }

    public override int InitiateBaseValue => 4;

    public override int AttackBaseValue => 16;

    public override int DefenseBaseValue => 72;

    public override int AimBaseValue => 0;

    public override int CombatValueModifierPerLevel => 7;

    public override int BaseQualificationPoints => 6;

    public override int QualificationPointsModifier => 10;

    public override int PercentQualificationModifier => 0;

    public override int BaseLifePoints => 6;

    public override int BasePainTolerancePoints => 6;

    public override bool AddFightValueOnFirstLevel => false;

    public override bool AddPainToleranceOnFirstLevel => false;

    public override bool AddQualificationPointsOnFirstLevel => true;

    public override QualificationList Qualifications => BuildQualifications(
    [
        new WeaponUse(),
        new PsiPyarron(QualificationLevel.Master),
        new LanguageLore(Language.Pyarronian, 5),
        new LanguageLore(Language.Shadonian, 5),
        new LanguageLore(Language.Erven, 5),
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
        new LanguageLore(Language.Toronian, 2, 3),
        new LanguageLore(Language.Doranian, 2, 3),
        new Healing(level: 3),
        new ReadingAndWriting(QualificationLevel.Master, 4),
        new LanguageLore(Language.Pyarronian, 6, 4),
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
    public override int GetPainToleranceModifier() => DiceThrow._1D6() + 2;

    public override string Name => "Priest of Nastar";
}
