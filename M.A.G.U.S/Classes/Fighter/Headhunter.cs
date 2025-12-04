using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.FightMode;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Combat;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Percentages;
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Qualifications.Specialities;
using M.A.G.U.S.Qualifications.Underworld;

namespace M.A.G.U.S.Classes.Fighter;

public class Headhunter : Class, IClass, IJustFight
{
    public Headhunter() : base(1) { }

    public Headhunter(byte level) : base(level)
    {
        GenerateSkills();
    }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    public override sbyte Strength { get; set; }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(12)]
    [SpecialTraining]
    public override sbyte Quickness { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    public override sbyte Dexterity { get; set; }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(12)]
    [SpecialTraining]
    public override sbyte Stamina { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(10)]
    public override sbyte Health { get; set; }

    [DiceThrow(ThrowType._3D6)]
    public override sbyte Beauty { get; set; }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override sbyte Intelligence { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    public override sbyte Willpower { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    public override sbyte Astral { get; set; }

    [DiceThrow(ThrowType._1D6)]
    public override byte Gold { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(8)]
    public override sbyte Bravery { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(8)]
    public override sbyte Erudition { get; set; }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(12)]
    public override sbyte Detection { get; set; }

    public override byte InitiatingBaseValue => 10;

    public override byte AttackingBaseValue => 20;

    public override byte DefendingBaseValue => 75;

    public override byte AimingBaseValue => 0;

    public override byte FightValueModifier => 11;

    public override byte BaseQualificationPoints => 3;

    public override byte QualificationPointsModifier => 5;

    public override byte PercentQualificationModifier => 20;

    public override byte BaseLifePoints => 6;

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
        new WeaponUse(),
        new WeaponUse(),
        new WeaponUse(),
        new WeaponUse(),
        new WeaponUse(),
        new WeaponThrowing(),
        new WeaponThrowing(),
        new WeaponThrowing(),
        new EscapeBonds(),
        new PsiPyarron(),
        new Swimming(),
        new Running(),
        new CamouflageOrDisguise(),
        new Backstab()
    ]);

    public override QualificationList FutureQualifications => BuildQualifications(
    [
        new EscapeBonds(level: 2),
        new EscapeBonds(QualificationLevel.Master, 2),
        new BlindFighting(level: 3),
        new TrackingConcealment(level: 4),
        new CamouflageOrDisguise(QualificationLevel.Master, 4),
        new PsiPyarron(QualificationLevel.Master, 5),
        new BlindFighting(QualificationLevel.Master, 7),
        new EscapeBonds(QualificationLevel.Master, 8),
        new TrackingConcealment(QualificationLevel.Master, 9)
    ]);

    public override List<PercentQualification> PercentQualifications =>
    [
        new Climbing(30),
        new Falling(15),
        new Jumping(15),
        new Sneaking(20),
        new Hiding(25),
        new TrapDetection(10)
    ];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new HeadHunterDamageIncreasing(),
        new UseOfSlanDisciplines(),
        new HeadHunterUnknownWeaponUse(),
        new HeadHunterInitiatingValueIncreasing()
    ];

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(5)]
    public override byte GetPainToleranceModifier() => (byte)(DiceThrow._1D6() + 5);

    public override string Name => "Assassin";
}
