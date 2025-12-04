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

namespace M.A.G.U.S.Classes.Sorcerer;

public class Wizard : Class, IClass, ILikeMagic
{
    public Wizard() : base(1) { }

    public Wizard(byte level) : base(level)
    {
        GenerateSkills();
    }

    [DiceThrow(ThrowType._3D6)]
    public override sbyte Strength { get; set; }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override sbyte Quickness { get; set; }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override sbyte Dexterity { get; set; }

    [DiceThrow(ThrowType._3D6)]
    public override sbyte Stamina { get; set; }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override sbyte Health { get; set; }

    [DiceThrow(ThrowType._3D6)]
    public override sbyte Beauty { get; set; }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(12)]
    [SpecialTraining]
    public override sbyte Intelligence { get; set; }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(12)]
    [SpecialTraining]
    public override sbyte Willpower { get; set; }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(12)]
    [SpecialTraining]
    public override sbyte Astral { get; set; }

    [DiceThrow(ThrowType._3D6)]
    public override byte Gold { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(8)]
    public override sbyte Bravery { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(8)]
    public override sbyte Erudition { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    public override sbyte Detection { get; set; }

    public override byte InitiatingBaseValue => 2;

    public override byte AttackingBaseValue => 15;

    public override byte DefendingBaseValue => 70;

    public override byte AimingBaseValue => 0;

    public override byte FightValueModifier => 4;

    public override byte BaseQualificationPoints => 7;

    public override byte QualificationPointsModifier => 7;

    public override byte PercentQualificationModifier => 0;

    public override byte BaseLifePoints => 3;

    public override byte BasePainTolerancePoints => 2;

    public override bool AddFightValueOnFirstLevel => false;

    public override bool AddPainToleranceOnFirstLevel => false;

    public override bool AddQualificationPointsOnFirstLevel => true;

    public override QualificationList Qualifications => BuildQualifications(
    [
        new WeaponUse(),
        new PsiKyrMethod(),
        new LanguageLore(5),
        new LanguageLore(4),
        new ReadingAndWriting(),
        new Alchemy(),
        new AncientTongueLore(),
        new Healing(),
        new Physiology(),
        new LegendLore(),
        new HistoryLore(),
        new RunicMagic()
    ]);

    public override QualificationList FutureQualifications => BuildQualifications(
    [
        new Herbalism(level: 4),
        new Alchemy(QualificationLevel.Master, 6),
        new RunicMagic(QualificationLevel.Master, 6),
        new LegendLore(QualificationLevel.Master, 7),
        new HistoryLore(QualificationLevel.Master, 8)
    ]);

    public override List<PercentQualification> PercentQualifications => [];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new Wizardry()
    ];

    [DiceThrow(ThrowType._1D6)]
    public override byte GetPainToleranceModifier() => (byte)DiceThrow._1D6();
}
