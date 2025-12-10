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

namespace M.A.G.U.S.Classes.Believer.GodsOfPyarron;

public class NastarPaladin : Class, IClass, IHateRangedWeapons
{
    public NastarPaladin() : base(1) { }

    public NastarPaladin(int level) : base(level)
    {
        GenerateSkills();
    }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    [SpecialTraining]
    public override int Strength { get; set; }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override int Quickness { get; set; }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override int Dexterity { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    public override int Stamina { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(10)]
    public override int Health { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    public override int Beauty { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    public override int Intelligence { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    public override int Willpower { get; set; }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(12)]
    public override int Astral { get; set; }

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

    public override int InitiatingBaseValue => 5;

    public override int AttackingBaseValue => 20;

    public override int DefendingBaseValue => 75;

    public override int AimingBaseValue => 0;

    public override int FightValueModifier => 9;

    public override int BaseQualificationPoints => 5;

    public override int QualificationPointsModifier => 5;

    public override int PercentQualificationModifier => 0;

    public override int BaseLifePoints => 6;

    public override int BasePainTolerancePoints => 7;

    public override bool AddFightValueOnFirstLevel => false;

    public override bool AddPainToleranceOnFirstLevel => false;

    public override bool AddQualificationPointsOnFirstLevel => true;

    public override QualificationList Qualifications => BuildQualifications(
    [
        new WeaponUse(),
        new WeaponUse(),
        new WeaponUse(),
        new WeaponUse(),
        new PsiPyarron(QualificationLevel.Master),
        new LanguageLore(Language.Pyarronian, 3),
        new LanguageLore(Language.Shadonian, 3),
        new LanguageLore(Language.Erven, 3),
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
    ]);

    public override QualificationList FutureQualifications => BuildQualifications(
    [
		// new HárítófegyverHasználat(level: 2)
		new Craft(Profession.Smith, level: 3),
        new HistoryLore(QualificationLevel.Master, 4),
        new Craft(Profession.Smith, QualificationLevel.Master, 6),
        new WeaponUse(QualificationLevel.Master, 8)
    ]);

    public override List<PercentQualification> PercentQualifications => [];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new ClericalMagic()
    ];

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(5)]
    public override int GetPainToleranceModifier() => DiceThrow._1D6() + 5;

    public override string Name => "Paladin of Nastar";
}
