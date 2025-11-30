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

namespace M.A.G.U.S.Classes.Sorcerer;

public class FireWizard : Class, IClass, ILikeMagic
{
    public FireWizard() : base(1) { }

    public FireWizard(byte level) : base(level) { }

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

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(6)]
    public override sbyte Astral { get; set; }

    [DiceThrow(ThrowType._3K6)]
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

    public override byte InitiatingBaseValue => 6;

    public override byte AttackingBaseValue => 17;

    public override byte DefendingBaseValue => 72;

    public override byte AimingBaseValue => 0;

    public override byte FightValueModifier => 8;

    public override byte BaseQualificationPoints => 3;

    public override byte QualificationPointsModifier => 5;

    public override byte PercentQualificationModifier => 0;

    public override byte BaseLifePoints => 5;

    public override byte BasePainTolerancePoints => 4;

    public override bool AddFightValueOnFirstLevel => false;

    public override bool AddPainToleranceOnFirstLevel => false;

    public override bool AddQualificationPointsOnFirstLevel => true;

    public override QualificationList Qualifications => BuildQualifications(
    [
        new WeaponUse(),
        new WeaponUse(),
        new PsiPyarron(QualificationLevel.Master),
        new LanguageLore(4),
        new LanguageLore(3),
        new ReadingAndWriting(),
        new Riding(),
        new Sailing()
    ]);

    public override QualificationList FutureQualifications => BuildQualifications([]);

    public override List<PercentQualification> PercentQualifications => [];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new FireMagic()
    ];

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(1)]
    public override byte GetPainToleranceModifier() => (byte)(DiceThrow._1K6() + 1);

    public override string Name => "Fire Mage";
}
