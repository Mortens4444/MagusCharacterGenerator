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

    public VelarPaladin(byte level) : base(level) { }

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(6)]
    public override sbyte Strength => DiceThrow._2K6_Plus_6();

    [DiceThrow(ThrowType._3K6_2_Times)]
    public override sbyte Quickness => DiceThrow._3K6_2_Times();

    [DiceThrow(ThrowType._3K6_2_Times)]
    public override sbyte Dexterity => DiceThrow._3K6_2_Times();

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(6)]
    public override sbyte Stamina => DiceThrow._2K6_Plus_6();

    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(8)]
    public override sbyte Health => DiceThrow._1K10_Plus_8();

    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(10)]
    public override sbyte Beauty => DiceThrow._1K10_Plus_10();

    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(8)]
    public override sbyte Intelligence => DiceThrow._1K10_Plus_8();

    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(8)]
    [SpecialTraining]
    public override sbyte Willpower => DiceThrow._1K10_Plus_8_Plus_SpecialTraining();

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(12)]
    [SpecialTraining]
    public override sbyte Astral => DiceThrow._1K6_Plus_12_Plus_SpecialTraining();

    [DiceThrow(ThrowType._1K6)]
    public override byte Gold => (byte)DiceThrow._1K6();

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(8)]
    public override sbyte Bravery => (sbyte)(DiceThrow._2K6() + 8);

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(8)]
    public override sbyte Erudition => (sbyte)(DiceThrow._2K6() + 8);

    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(8)]
    public override sbyte Detection => (sbyte)(DiceThrow._1K10_Plus_8());

    public override byte InitiatingBaseValue => 5;

    public override byte AttackingBaseValue => 20;

    public override byte DefendingBaseValue => 75;

    public override byte AimingBaseValue => 0;

    public override byte FightValueModifier => 9;

    public override byte BaseQualificationPoints => 5;

    public override byte QualificationPointsModifier => 5;

    public override byte PercentQualificationModifier => 0;

    public override byte BaseLifePoints => 8;

    public override byte BasePainTolerancePoints => 7;

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

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(3)]
    public override byte GetPainToleranceModifier() => (byte)(DiceThrow._1K6() + 3);

    public override string Name => "Paladin of Velar";
}
