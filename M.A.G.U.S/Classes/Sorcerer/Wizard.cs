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

    public Wizard(byte level) : base(level) { }

    [DiceThrow(ThrowType._3K6)]
    public override sbyte Strength => DiceThrow._3K6();

    [DiceThrow(ThrowType._3K6_2_Times)]
    public override sbyte Quickness => DiceThrow._3K6_2_Times();

    [DiceThrow(ThrowType._3K6_2_Times)]
    public override sbyte Dexterity => DiceThrow._3K6_2_Times();

    [DiceThrow(ThrowType._3K6)]
    public override sbyte Stamina => DiceThrow._3K6();

    [DiceThrow(ThrowType._3K6_2_Times)]
    public override sbyte Health => DiceThrow._3K6_2_Times();

    [DiceThrow(ThrowType._3K6)]
    public override sbyte Beauty => DiceThrow._3K6();

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(12)]
    [SpecialTraining]
    public override sbyte Intelligence => DiceThrow._1K6_Plus_12_Plus_SpecialTraining();

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(12)]
    [SpecialTraining]
    public override sbyte Willpower => DiceThrow._1K6_Plus_12_Plus_SpecialTraining();

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(12)]
    [SpecialTraining]
    public override sbyte Astral => DiceThrow._1K6_Plus_12_Plus_SpecialTraining();

    [DiceThrow(ThrowType._3K6)]
    public override byte Gold => (byte)DiceThrow._3K6();

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(8)]
    public override sbyte Bravery => (sbyte)(DiceThrow._2K6() + 8);

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(8)]
    public override sbyte Erudition => (sbyte)(DiceThrow._2K6() + 8);

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(6)]
    public override sbyte Detection => (sbyte)(DiceThrow._2K6() + 6);

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

    [DiceThrow(ThrowType._1K6)]
    public override byte GetPainToleranceModifier() => (byte)DiceThrow._1K6();
}
