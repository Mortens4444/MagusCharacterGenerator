using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Battle;

namespace M.A.G.U.S.Classes.NonPlayableCharacters;

public class GuardOfficer(byte level = 1) : Class(level), IClass
{
    [DiceThrow(ThrowType._3K6)]
    public override short Strength => DiceThrow._3K6();

    [DiceThrow(ThrowType._3K6)]
    public override short Speed => DiceThrow._3K6();

    [DiceThrow(ThrowType._3K6)]
    public override short Dexterity => DiceThrow._3K6();

    [DiceThrow(ThrowType._3K6)]
    public override short Stamina => DiceThrow._3K6();

    [DiceThrow(ThrowType._3K6)]
    public override short Health => DiceThrow._3K6();

    [DiceThrow(ThrowType._2K6)]
    public override short Beauty => DiceThrow._2K6();

    [DiceThrow(ThrowType._2K6)]
    public override short Intelligence => DiceThrow._2K6();

    [DiceThrow(ThrowType._2K6)]
    public override short WillPower => DiceThrow._2K6();

    [DiceThrow(ThrowType._2K6)]
    public override short Astral => DiceThrow._2K6();

    [DiceThrow(ThrowType._1K10)]
    public override short Gold => DiceThrow._1K10();

    [DiceThrow(ThrowType._3K6)]
    public override byte Bravery => (byte)DiceThrow._3K6();

    [DiceThrow(ThrowType._2K6)]
    public override byte Erudition => (byte)DiceThrow._2K6();

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

    public override QualificationList Qualifications =>
    [
        new WeaponUse(),
        new WeaponUse(),
        new HeavyArmorWearing(),
        new ShieldUse(),
        new Leadership()
   ];

    public override QualificationList FutureQualifications => [];

    public override List<PercentQualification> PercentQualifications => [];

    public override SpecialQualificationList SpecialQualifications => [];

    [DiceThrow(ThrowType._1K5)]
    public override byte GetPainToleranceModifier() => (byte)DiceThrow._1K5();

    public override string ClassName => "Guard officer";
}
