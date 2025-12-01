using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.FightMode;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Combat;
using M.A.G.U.S.Qualifications.Magic;
using M.A.G.U.S.Qualifications.Percentages;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Qualifications.Underworld;

namespace M.A.G.U.S.Classes.Sorcerer;

public class Warlock : Class, IClass, ILikeMagic
{
    public Warlock() : base(1) { }

    public Warlock(byte level) : base(level)
    {
        GenerateSkills();
    }

    [DiceThrow(ThrowType._3K6_2_Times)]
    public override sbyte Strength { get; set; }

    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(8)]
    public override sbyte Quickness { get; set; }

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(12)]
    [SpecialTraining]
    public override sbyte Dexterity { get; set; }

    [DiceThrow(ThrowType._3K6_2_Times)]
    public override sbyte Stamina { get; set; }

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(6)]
    public override sbyte Health { get; set; }

    [DiceThrow(ThrowType._3K6)]
    public override sbyte Beauty { get; set; }

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(6)]
    public override sbyte Intelligence { get; set; }

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(6)]
    public override sbyte Willpower { get; set; }

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(12)]
    public override sbyte Astral { get; set; }

    [DiceThrow(ThrowType._2K6)]
    public override byte Gold { get; set; }

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(8)]
    public override sbyte Bravery { get; set; }

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(8)]
    public override sbyte Erudition { get; set; }

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(6)]
    public override sbyte Detection { get; set; }

    public override byte InitiatingBaseValue => 7;

    public override byte AttackingBaseValue => 17;

    public override byte DefendingBaseValue => 72;

    public override byte AimingBaseValue => 5;

    public override byte FightValueModifier => 7;

    public override byte BaseQualificationPoints => 7;

    public override byte QualificationPointsModifier => 8;

    public override byte PercentQualificationModifier => 15;

    public override byte BaseLifePoints => 3;

    public override byte BasePainTolerancePoints => 4;

    public override bool AddFightValueOnFirstLevel => false;

    public override bool AddPainToleranceOnFirstLevel => false;

    public override bool AddQualificationPointsOnFirstLevel => true;

    public override QualificationList Qualifications => BuildQualifications(
    [
        new WeaponUse(),
        new WeaponUse(),
        new WeaponUse(),
        new WeaponThrowing(),
        new PsiPyarron(QualificationLevel.Master),
        new LanguageLore(3),
        new LanguageLore(3),
        new LanguageLore(2),
        new ReadingAndWriting(),
        new PoisoningAndNeutralization(),
        new CamouflageOrDisguise(),
        new Herbalism(),
    ]);

    public override QualificationList FutureQualifications => BuildQualifications(
    [
        new Backstab(level: 2),
        new PoisoningAndNeutralization(QualificationLevel.Master, 4),
        new Backstab(QualificationLevel.Master, 5),
        new Herbalism(QualificationLevel.Master, 6)
    ]);

    public override List<PercentQualification> PercentQualifications =>
    [
        new Sneaking(15),
        new Hiding(15)
    ];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new Warlockry()
    ];

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(1)]
    public override byte GetPainToleranceModifier() => (byte)(DiceThrow._1K6() + 1);
}
