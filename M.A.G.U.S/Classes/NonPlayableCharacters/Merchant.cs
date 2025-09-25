﻿using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.NonPlayableCharacterQualifications;

namespace M.A.G.U.S.Classes.NonPlayableCharacters;

public class Merchant(byte level = 1) : Class(level), IClass
{
    [DiceThrow(ThrowType._2K6)]
    public override short Strength => DiceThrow._2K6();

    [DiceThrow(ThrowType._2K6)]
    public override short Speed => DiceThrow._2K6();

    [DiceThrow(ThrowType._2K6)]
    public override short Dexterity => DiceThrow._2K6();

    [DiceThrow(ThrowType._1K10)]
    public override short Stamina => DiceThrow._1K10();

    [DiceThrow(ThrowType._2K6)]
    public override short Health => DiceThrow._2K6();

    [DiceThrow(ThrowType._2K6)]
    public override short Beauty => DiceThrow._2K6();

    [DiceThrow(ThrowType._2K6)]
    public override short Intelligence => DiceThrow._2K6();

    [DiceThrow(ThrowType._2K6)]
    public override short Willpower => DiceThrow._2K6();

    [DiceThrow(ThrowType._2K6)]
    public override short Astral => DiceThrow._2K6();

    [DiceThrow(ThrowType._1K100)]
    public override short Gold => DiceThrow._1K100();

    [DiceThrow(ThrowType._1K6)]
    public override byte Bravery => (byte)DiceThrow._1K6();

    [DiceThrow(ThrowType._2K6)]
    public override byte Erudition => (byte)DiceThrow._2K6();

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

    public override QualificationList Qualifications =>
    [
        new Appraisal(),
        new CourierHerald()
   ];

    public override QualificationList FutureQualifications => [];

    public override List<PercentQualification> PercentQualifications => [];

    public override SpecialQualificationList SpecialQualifications => [];

    [DiceThrow(ThrowType._1K2)]
    public override byte GetPainToleranceModifier() => (byte)DiceThrow._1K2();
}
