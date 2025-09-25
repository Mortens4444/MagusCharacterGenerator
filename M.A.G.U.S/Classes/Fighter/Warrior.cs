﻿using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.FightMode;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Battle;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Percentages;

namespace M.A.G.U.S.Classes.Fighter;

public class Warrior(byte level = 1) : Class(level), IClass, IJustFight
{
    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(12)]
    [SpecialTraining]
    public override short Strength => DiceThrow._1K6_Plus_12_Plus_SpecialTraining();

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(6)]
    [SpecialTraining]
    public override short Speed => DiceThrow._2K6_Plus_6_Plus_SpecialTraining();

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(6)]
    [SpecialTraining]
    public override short Dexterity => DiceThrow._2K6_Plus_6_Plus_SpecialTraining();

    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(8)]
    [SpecialTraining]
    public override short Stamina => DiceThrow._1K10_Plus_8_Plus_SpecialTraining();

    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(10)]
    public override short Health => DiceThrow._1K10_Plus_10();

    [DiceThrow(ThrowType._3K6_2_Times)]
    public override short Beauty => DiceThrow._3K6_2_Times();

    [DiceThrow(ThrowType._3K6_2_Times)]
    public override short Intelligence => DiceThrow._3K6_2_Times();

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(6)]
    public override short Willpower => DiceThrow._2K6_Plus_6();

    [DiceThrow(ThrowType._3K6_2_Times)]
    public override short Astral => DiceThrow._3K6_2_Times();

    [DiceThrow(ThrowType._3K6)]
    public override short Gold => DiceThrow._3K6();

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(8)]
    public override byte Bravery => (byte)(DiceThrow._2K6() + 8);

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(8)]
    public override byte Erudition => (byte)(DiceThrow._2K6() + 8);

    public override byte InitiatingBaseValue => 9;

    public override byte AttackingBaseValue => 20;

    public override byte DefendingBaseValue => 75;

    public override byte AimingBaseValue => 0;

    public override byte FightValueModifier => 11;

    public override byte BaseQualificationPoints => 10;

    public override byte QualificationPointsModifier => 14;

    public override byte PercentQualificationModifier => 0;

    public override byte BaseLifePoints => 7;

    public override byte BasePainTolerancePoints => 6;

    public override bool AddFightValueOnFirstLevel => true;

    public override bool AddPainToleranceOnFirstLevel => true;

    public override bool AddQualificationPointsOnFirstLevel => true;

    public override QualificationList Qualifications =>
    [
        new WeaponUse(),
            new WeaponUse(),
            new WeaponUse(),
            new Riding(),
            new Swimming(),
            new Running()
    ];

    public override QualificationList FutureQualifications =>
    [
        new Leadership(level: 6)
    ];

    public override List<PercentQualification> PercentQualifications =>
    [
        new Climbing(15),
            new Falling(20),
            new Jumping(10)
    ];

    public override SpecialQualificationList SpecialQualifications => [];

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(4)]
    public override byte GetPainToleranceModifier() => (byte)(DiceThrow._1K6() + 4);
}
