using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.FightMode;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Combat;
using M.A.G.U.S.Qualifications.Magic;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Classes.Believer.GodsOfPyarron;

public class VelarMonk : Class, IClass, ILikeMagic
{
    public VelarMonk() : base(1) { }

    public VelarMonk(byte level) : base(level) { }

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(6)]
    public override sbyte Strength { get; set; }

    [DiceThrow(ThrowType._3K6_2_Times)]
    public override sbyte Quickness { get; set; }

    [DiceThrow(ThrowType._3K6_2_Times)]
    public override sbyte Dexterity { get; set; }

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(6)]
    public override sbyte Stamina { get; set; }

    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(8)]
    public override sbyte Health { get; set; }

    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(10)]
    public override sbyte Beauty { get; set; }

    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(8)]
    public override sbyte Intelligence { get; set; }

    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(8)]
    [SpecialTraining]
    public override sbyte Willpower { get; set; }

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(12)]
    [SpecialTraining]
    public override sbyte Astral { get; set; }

    [DiceThrow(ThrowType._1K6)]
    public override byte Gold { get; set; }

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(8)]
    public override sbyte Bravery { get; set; }

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(8)]
    public override sbyte Erudition { get; set; }

    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(8)]
    public override sbyte Detection { get; set; }

    public override byte InitiatingBaseValue => 6;

    public override byte AttackingBaseValue => 15;

    public override byte DefendingBaseValue => 75;

    public override byte AimingBaseValue => 0;

    public override byte FightValueModifier => 8;

    public override byte BaseQualificationPoints => 5;

    public override byte QualificationPointsModifier => 7;

    public override byte PercentQualificationModifier => 0;

    public override byte BaseLifePoints => 4;

    public override byte BasePainTolerancePoints => 8;

    public override bool AddFightValueOnFirstLevel => false;

    public override bool AddPainToleranceOnFirstLevel => false;

    public override bool AddQualificationPointsOnFirstLevel => true;

    public override QualificationList Qualifications => BuildQualifications(
    [
        new WeaponUse(),
        new ReadingAndWriting(),
        new LanguageLore(4),
        new AncientTongueLore(),
        new PsiPyarron(QualificationLevel.Master),
        new Healing(),
        new ReligionLore(QualificationLevel.Master),
        new Fistfight(QualificationLevel.Master)

       // TODO
       //new Kínzás elviselése(QualificationLevel.Master),
       //new Kultúra (QualificationLevel.Master) //Saját
       //new Helyismeret 60%
    ]);

    public override QualificationList FutureQualifications => BuildQualifications(
    [
        new Physiology(level: 4),
        new PoisoningAndNeutralization(level: 4),
        new Demonology(level: 5),
        new WeaponUse(QualificationLevel.Master, 5),
        new AncientTongueLore(QualificationLevel.Master, 6),
        new Healing(QualificationLevel.Master, 7),
        new PoisoningAndNeutralization(QualificationLevel.Master, 8)
    ]);

    public override List<PercentQualification> PercentQualifications => [];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new PsiSiegeKyrDisciplineUsage(),
        new ClericalMagic()
    ];

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(5)]
    public override byte GetPainToleranceModifier() => (byte)(DiceThrow._1K6() + 5);

    public override string Name => "Monk of Velar";
}
