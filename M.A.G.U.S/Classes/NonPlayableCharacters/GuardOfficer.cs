using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Combat;

namespace M.A.G.U.S.Classes.NonPlayableCharacters;

public class GuardOfficer : Class, IClass
{
    public GuardOfficer() : base(1) { }

    public GuardOfficer(byte level) : base(level)
    {
        GenerateSkills();
    }

    [DiceThrow(ThrowType._3K6)]
    public override sbyte Strength { get; set; }

    [DiceThrow(ThrowType._3K6)]
    public override sbyte Quickness { get; set; }

    [DiceThrow(ThrowType._3K6)]
    public override sbyte Dexterity { get; set; }

    [DiceThrow(ThrowType._3K6)]
    public override sbyte Stamina { get; set; }

    [DiceThrow(ThrowType._3K6)]
    public override sbyte Health { get; set; }

    [DiceThrow(ThrowType._2K6)]
    public override sbyte Beauty { get; set; }

    [DiceThrow(ThrowType._2K6)]
    public override sbyte Intelligence { get; set; }

    [DiceThrow(ThrowType._2K6)]
    public override sbyte Willpower { get; set; }

    [DiceThrow(ThrowType._2K6)]
    public override sbyte Astral { get; set; }

    [DiceThrow(ThrowType._1K10)]
    public override byte Gold { get; set; }

    [DiceThrow(ThrowType._3K6)]
    public override sbyte Bravery { get; set; }

    [DiceThrow(ThrowType._2K6)]
    public override sbyte Erudition { get; set; }

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(6)]
    public override sbyte Detection { get; set; }

    public override byte InitiatingBaseValue => 5;

    public override byte AttackingBaseValue => 20;

    public override byte DefendingBaseValue => 70;

    public override byte AimingBaseValue => 0;

    public override byte FightValueModifier => 7;

    public override byte BaseQualificationPoints => 0;

    public override byte QualificationPointsModifier => 1;

    public override byte PercentQualificationModifier => 0;

    public override byte BaseLifePoints => 5;

    public override byte BasePainTolerancePoints => 15;

    public override bool AddFightValueOnFirstLevel => false;

    public override bool AddPainToleranceOnFirstLevel => false;

    public override bool AddQualificationPointsOnFirstLevel => false;

    public override QualificationList Qualifications => BuildQualifications(
    [
        new WeaponUse(),
        new WeaponUse(),
        new HeavyArmorWearing(),
        new ShieldUse(),
        new Leadership()
    ]);

    public override QualificationList FutureQualifications => BuildQualifications([]);

    public override List<PercentQualification> PercentQualifications => [];

    public override SpecialQualificationList SpecialQualifications => [];

    [DiceThrow(ThrowType._1K5)]
    public override byte GetPainToleranceModifier() => (byte)DiceThrow._1K5();

    public override string Name => "Guard officer";
}
