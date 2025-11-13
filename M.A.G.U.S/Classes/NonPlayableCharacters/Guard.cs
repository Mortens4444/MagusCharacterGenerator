using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Combat;

namespace M.A.G.U.S.Classes.NonPlayableCharacters;

public class Guard(byte level = 1) : Class(level), IClass
{
    [DiceThrow(ThrowType._3K6)]
    public override sbyte Strength => DiceThrow._3K6();

    [DiceThrow(ThrowType._2K6)]
    public override sbyte Quickness => DiceThrow._2K6();

    [DiceThrow(ThrowType._2K6)]
    public override sbyte Dexterity => DiceThrow._2K6();

    [DiceThrow(ThrowType._3K6)]
    public override sbyte Stamina => DiceThrow._3K6();

    [DiceThrow(ThrowType._3K6)]
    public override sbyte Health => DiceThrow._3K6();

    [DiceThrow(ThrowType._2K6)]
    public override sbyte Beauty => DiceThrow._2K6();

    [DiceThrow(ThrowType._2K6)]
    public override sbyte Intelligence => DiceThrow._2K6();

    [DiceThrow(ThrowType._2K6)]
    public override sbyte Willpower => DiceThrow._2K6();

    [DiceThrow(ThrowType._2K6)]
    public override sbyte Astral => DiceThrow._2K6();

    [DiceThrow(ThrowType._1K5)]
    public override byte Gold => (byte)DiceThrow._1K5();

    [DiceThrow(ThrowType._2K6)]
    public override sbyte Bravery => (sbyte)DiceThrow._2K6();

    [DiceThrow(ThrowType._1K6)]
    public override sbyte Erudition => (sbyte)DiceThrow._1K6();

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(6)]
    public override sbyte Detection => (sbyte)(DiceThrow._2K6() + 6);

    public override byte InitiatingBaseValue => 3;

    public override byte AttackingBaseValue => 15;

    public override byte DefendingBaseValue => 65;

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

    public override QualificationList Qualifications =>
    [
        new WeaponUse(),
        new WeaponUse(),
        new HeavyArmorWearing(),
        new ShieldUse()
    ];

    public override QualificationList FutureQualifications => [];

    public override List<PercentQualification> PercentQualifications => [];

    public override SpecialQualificationList SpecialQualifications => [];

    [DiceThrow(ThrowType._1K5)]
    public override byte GetPainToleranceModifier() => (byte)DiceThrow._1K5();
}
