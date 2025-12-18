using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.FightMode;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Combat;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Percentages;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Qualifications.Specialities;
using M.A.G.U.S.Races;

namespace M.A.G.U.S.Classes.Slan;

public class MartialArtist : Class, IClass, IJustFight
{
    public MartialArtist() : base(1) { }

    public MartialArtist(int level) : base(level)
    {
        GenerateSkills();
    }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    public override int Strength { get; set; }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(14)]
    public override int Quickness { get; set; }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(12)]
    public override int Dexterity { get; set; }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(12)]
    public override int Stamina { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(10)]
    public override int Health { get; set; }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override int Beauty { get; set; }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override int Intelligence { get; set; }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(12)]
    public override int Willpower { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    public override int Astral { get; set; }

    [DiceThrow(ThrowType._1D3)]
    public override int Gold { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(8)]
    public override int Bravery { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(8)]
    public override int Erudition { get; set; }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(12)]
    public override int Detection { get; set; }

    public override int InitiatingBaseValue => 10;

    public override int AttackingBaseValue => 20;

    public override int DefendingBaseValue => 75;

    public override int AimingBaseValue => 0;

    public override int FightValueModifier => 8;

    public override int BaseQualificationPoints => 4;

    public override int QualificationPointsModifier => 5;

    public override int PercentQualificationModifier => 22;

    public override int BaseLifePoints => 4;

    public override int BasePainTolerancePoints => 8;

    public override bool AddFightValueOnFirstLevel => true;

    public override bool AddPainToleranceOnFirstLevel => false;

    public override bool AddQualificationPointsOnFirstLevel => true;

    public override IRace[] AllowedRaces => [new Human(), new HalfElf(), new Amund(), new Jann()];

    public override QualificationList Qualifications => BuildQualifications(
    [
        new PsiSlanWay(),
        new WeaponUse(),
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
        new WeaponThrowing(),
        new WeaponBreaking(),
        new Riding(),
        new Swimming(),
        new Running(),
        new BlindFighting()
    ]);

    public override QualificationList FutureQualifications => BuildQualifications(
    [
        new Healing(level: 2),
        new WeaponBreaking(QualificationLevel.Master, 4),
        new BlindFighting(QualificationLevel.Master, 5),
        new Healing(QualificationLevel.Master, 6)
    ]);

    public override List<PercentQualification> PercentQualifications =>
    [
        new Climbing(20),
        new Falling(35),
        new Jumping(30)
    ];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new SlanDodgeAgainstRangedAttacks(),
        new BareHandFighterRunning(),
        new BareHandFighterMagicHand()
    ];

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(5)]
    public override int GetPainToleranceModifier() => DiceThrow._1D6() + 5;

    public override string Name => "Martial Artist";
}
