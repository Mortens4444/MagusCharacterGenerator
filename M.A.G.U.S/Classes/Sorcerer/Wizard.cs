﻿using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.FightMode;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Combat;
using M.A.G.U.S.Qualifications.Magic;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Qualifications.Scientific.Psi;

namespace M.A.G.U.S.Classes.Sorcerer;

public class Wizard(byte level = 1) : Class(level), IClass, ILikeMagic
{
    [DiceThrow(ThrowType._3K6)]
    public override short Strength => DiceThrow._3K6();

    [DiceThrow(ThrowType._3K6_2_Times)]
    public override short Speed => DiceThrow._3K6_2_Times();

    [DiceThrow(ThrowType._3K6_2_Times)]
    public override short Dexterity => DiceThrow._3K6_2_Times();

    [DiceThrow(ThrowType._3K6)]
    public override short Stamina => DiceThrow._3K6();

    [DiceThrow(ThrowType._3K6_2_Times)]
    public override short Health => DiceThrow._3K6_2_Times();

    [DiceThrow(ThrowType._3K6)]
    public override short Beauty => DiceThrow._3K6();

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(12)]
    [SpecialTraining]
    public override short Intelligence => DiceThrow._1K6_Plus_12_Plus_SpecialTraining();

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(12)]
    [SpecialTraining]
    public override short Willpower => DiceThrow._1K6_Plus_12_Plus_SpecialTraining();

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(12)]
    [SpecialTraining]
    public override short Astral => DiceThrow._1K6_Plus_12_Plus_SpecialTraining();

    [DiceThrow(ThrowType._3K6)]
    public override short Gold => DiceThrow._3K6();

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(8)]
    public override byte Bravery => (byte)(DiceThrow._2K6() + 8);

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(8)]
    public override byte Erudition => (byte)(DiceThrow._2K6() + 8);

    public override byte InitiatingBaseValue => 2;

    public override byte AttackingBaseValue => 15;

    public override byte DefendingBaseValue => 70;

    public override byte AimingBaseValue => 0;

    public override byte FightValueModifier => 4;

    public override byte BaseQualificationPoints => 7;

    public override byte QualificationPointsModifier => 7;

    public override byte PercentQualificationModifier => 0;

    public override byte BaseLifePoints => 3;

    public override byte BasePainTolerancePoints => 2;

    public override bool AddFightValueOnFirstLevel => false;

    public override bool AddPainToleranceOnFirstLevel => false;

    public override bool AddQualificationPointsOnFirstLevel => true;

    public override QualificationList Qualifications =>
    [
        new WeaponUse(),
        new PsiKyrMethod(),
        new LanguageLore(5),
        new LanguageLore(4),
        new ReadingAndWriting(),
        new Alchemy(),
        new AncientTongueLore(),
        new Healing(),
        new Physiology(),
        new LegendLore(),
        new HistoryLore(),
        new RunicMagic()
   ];

    public override QualificationList FutureQualifications =>
    [
        new Herbalism(level: 4),
        new Alchemy(QualificationLevel.Master, 6),
        new RunicMagic(QualificationLevel.Master, 6),
        new LegendLore(QualificationLevel.Master, 7),
        new HistoryLore(QualificationLevel.Master, 8)
    ];

    public override List<PercentQualification> PercentQualifications => [];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new Wizardry()
    ];

    [DiceThrow(ThrowType._1K6)]
    public override byte GetPainToleranceModifier() => (byte)DiceThrow._1K6();
}
