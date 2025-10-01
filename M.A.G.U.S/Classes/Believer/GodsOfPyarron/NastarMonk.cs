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
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Classes.Believer.GodsOfPyarron;

public class NastarMonk(byte level = 1) : Class(level), IClass, ILikeMagic
{
    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(6)]
    public override short Strength => DiceThrow._2K6_Plus_6();

    [DiceThrow(ThrowType._3K6_2_Times)]
    public override short Speed => DiceThrow._3K6_2_Times();

    [DiceThrow(ThrowType._3K6_2_Times)]
    public override short Dexterity => DiceThrow._3K6_2_Times();

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(6)]
    public override short Stamina => DiceThrow._2K6_Plus_6();

    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(8)]
    public override short Health => DiceThrow._1K10_Plus_8();

    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(10)]
    public override short Beauty => DiceThrow._1K10_Plus_10();

    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(8)]
    public override short Intelligence => DiceThrow._1K10_Plus_8();

    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(8)]
    [SpecialTraining]
    public override short Willpower => DiceThrow._1K10_Plus_8_Plus_SpecialTraining();

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(12)]
    [SpecialTraining]
    public override short Astral => DiceThrow._1K6_Plus_12_Plus_SpecialTraining();

    [DiceThrow(ThrowType._1K6)]
    public override short Gold => DiceThrow._1K6();

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(8)]
    public override byte Bravery => (byte)(DiceThrow._2K6() + 8);

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(8)]
    public override byte Erudition => (byte)(DiceThrow._2K6() + 8);

    public override byte InitiatingBaseValue => 4;

    public override byte AttackingBaseValue => 14;

    public override byte DefendingBaseValue => 75;

    public override byte AimingBaseValue => 0;

    public override byte FightValueModifier => 7;

    public override byte BaseQualificationPoints => 5;

    public override byte QualificationPointsModifier => 8;

    public override byte PercentQualificationModifier => 0;

    public override byte BaseLifePoints => 4;

    public override byte BasePainTolerancePoints => 8;

    public override bool AddFightValueOnFirstLevel => false;

    public override bool AddPainToleranceOnFirstLevel => false;

    public override bool AddQualificationPointsOnFirstLevel => true;

    public override QualificationList Qualifications =>
    [
        new WeaponUse(),
        new PsiPyarron(QualificationLevel.Master),
        new LanguageLore(5),
        new LanguageLore(5),
        new LanguageLore(5),
        new Physiology(),
        new ReadingAndWriting(),
        new Healing(),
        new ReligionLore(),

		// TODO
		//new Emberismeret
		//new Erkölcs(QualificationLevel.Master),
		//new Helyismeret 60%
		//new Kultúra(QualificationLevel.Master), Saját
		//new KínzásElviselése()
    ];

    public override QualificationList FutureQualifications =>
    [
		//new Emberismeret MF 3
		new ReadingAndWriting(QualificationLevel.Master, 4),
        new Herbalism(level: 5),
        new AncientTongueLore(level: 5),
        new Demonology(level: 6),
        new AncientTongueLore(QualificationLevel.Master, 7)
    ];

    public override List<PercentQualification> PercentQualifications => [];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new PsiSiegeKyrDisciplineUsage(),
        new ClericalMagic(),
        new UseOfSlanDisciplines()
    ];

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(5)]
    public override byte GetPainToleranceModifier() => (byte)(DiceThrow._1K6() + 5);

    public override string Name => "Monk of Nastar";
}
