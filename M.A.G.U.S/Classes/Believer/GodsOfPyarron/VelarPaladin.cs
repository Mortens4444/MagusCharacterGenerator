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

public class VelarPaladin : Class, IClass, ILikeMagic
{
    public VelarPaladin() : base(1) { }

    public VelarPaladin(int level) : base(level)
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
    [DiceThrowModifier(12)]
    [SpecialTraining]
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

    public override int BaseLifePoints => 8;

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
        new SingingAndMakingMusic(),
        new Etiquette(),
        new ReadingAndWriting(),
        new TwoHandedCombat(),
        new HeavyArmorWearing(),
        new LanguageLore(4),
        new PsiPyarron(QualificationLevel.Master),
        new Healing(),
        new ReligionLore(QualificationLevel.Master),
        new HistoryLore(),

		// TODO
		//new Emberismeret()
		//new Erkölcs(QualificationLevel.Master),
		//new Helyismeret 60%
		//new Kultúra (QualificationLevel.Master) //Saját
		//new Jog/Törvénykezés()
    ]);

    public override QualificationList FutureQualifications => BuildQualifications(
    [
        new Heraldry(level: 2),
		//new Emberismeret(QualificationLevel.Master, 3)
		//new Jog/Törvénykezés(QualificationLevel.Master, 3)
		new Healing(QualificationLevel.Master, 4),
        new Leadership(level: 5),
        new TwoHandedCombat(QualificationLevel.Master, 6)
    ]);

    public override List<PercentQualification> PercentQualifications => [];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new PsiSiegeKyrDisciplineUsage(),
        new ClericalMagic()
    ];

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(3)]
    public override int GetPainToleranceModifier() => DiceThrow._1D6() + 3;

    public override string Name => "Paladin of Velar";
}
