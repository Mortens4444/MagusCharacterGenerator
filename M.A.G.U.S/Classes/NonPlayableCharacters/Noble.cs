using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Combat;
using M.A.G.U.S.Qualifications.Scientific;

namespace M.A.G.U.S.Classes.NonPlayableCharacters;

public class Noble : Class, IClass
{
    public Noble() : base(1) { }

    public Noble(byte level) : base(level)
    {
        GenerateSkills();
    }

    [DiceThrow(ThrowType._1K10)]
    public override sbyte Strength { get; set; }

    [DiceThrow(ThrowType._1K10)]
    public override sbyte Quickness { get; set; }

    [DiceThrow(ThrowType._1K10)]
    public override sbyte Dexterity { get; set; }

    [DiceThrow(ThrowType._1K10)]
    public override sbyte Stamina { get; set; }

    [DiceThrow(ThrowType._2K6)]
    public override sbyte Health { get; set; }

    [DiceThrow(ThrowType._2K6)]
    public override sbyte Beauty { get; set; }

    [DiceThrow(ThrowType._2K6)]
    public override sbyte Intelligence { get; set; }

    [DiceThrow(ThrowType._2K6)]
    public override sbyte Willpower { get; set; }

    [DiceThrow(ThrowType._2K6)]
    public override sbyte Astral { get; set; }

    [DiceThrow(ThrowType._3K100)]
    public override byte Gold { get; set; }

    [DiceThrow(ThrowType._1K6)]
    public override sbyte Bravery { get; set; }

    [DiceThrow(ThrowType._1K6)]
    public override sbyte Erudition { get; set; }

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(6)]
    public override sbyte Detection { get; set; }

    public override byte InitiatingBaseValue => 1;

    public override byte AttackingBaseValue => 5;

    public override byte DefendingBaseValue => 50;

    public override byte AimingBaseValue => 0;

    public override byte FightValueModifier => 4;

    public override byte BaseQualificationPoints => 0;

    public override byte QualificationPointsModifier => 0;

    public override byte PercentQualificationModifier => 0;

    public override byte BaseLifePoints => 3;

    public override byte BasePainTolerancePoints => 10;

    public override bool AddFightValueOnFirstLevel => false;

    public override bool AddPainToleranceOnFirstLevel => false;

    public override bool AddQualificationPointsOnFirstLevel => false;

    public override QualificationList Qualifications => BuildQualifications(
    [
        new WeaponUse(),
        new ReadingAndWriting()
    ]);

    public override QualificationList FutureQualifications => BuildQualifications([]);

    public override List<PercentQualification> PercentQualifications => [];

    public override SpecialQualificationList SpecialQualifications => [];

    [DiceThrow(ThrowType._1K2)]
    public override byte GetPainToleranceModifier() => (byte)DiceThrow._1K2();
}
