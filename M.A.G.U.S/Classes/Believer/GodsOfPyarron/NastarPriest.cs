﻿using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.FightMode;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Battle;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Magic;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Classes.Believer.GodsOfPyarron;

/// <summary>
/// Nastar = Krad
/// https://nemaakos.files.wordpress.com/2014/10/nastar2.pdf
/// </summary>
public class NastarPriest(byte level) : Class(level), IClass, ILikeMagic
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
    public override short WillPower => DiceThrow._1K10_Plus_8_Plus_SpecialTraining();

    [DiceThrow(ThrowType._1K6)]
    public override short Gold => DiceThrow._1K6();

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(8)]
    public override byte Bravery => (byte)(DiceThrow._2K6() + 8);

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(8)]
    public override byte Erudition => (byte)(DiceThrow._2K6() + 8);

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(12)]
    [SpecialTraining]
    public override short Astral => DiceThrow._1K6_Plus_12_Plus_SpecialTraining();

    public override byte InitiatingBaseValue => 4;

    public override byte AttackingBaseValue => 16;

    public override byte DefendingBaseValue => 72;

    public override byte AimingBaseValue => 0;

    public override byte FightValueModifier => 7;

    public override byte BaseQualificationPoints => 6;

    public override byte QualificationPointsModifier => 10;

    public override byte PercentQualificationModifier => 0;

    public override byte BaseLifePoints => 6;

    public override byte BasePainTolerancePoints => 6;

    public override bool AddFightValueOnFirstLevel => false;

    public override bool AddPainToleranceOnFirstLevel => false;

    public override bool AddQualificationPointsOnFirstLevel => true;

    public override QualificationList Qualifications =>
    [
        new WeaponUsage(),
        new PsiPyarron(QualificationLevel.Master),
        new LanguageKnowledge(5),
        new LanguageKnowledge(5),
        new LanguageKnowledge(5),
        new Etiquette(),
        new ReadingAndWriting(),
        new Herbalism(),
        new ReligionKnowledge(QualificationLevel.Master),
        new HistoryKnowledge(),
        new LegendKnowledge(),
        new ProfessionKnowledge(Profession.Jeweler),

		// TODO
		//new Emberismeret()
		//new Erkölcs(),
		//new Helyismeret 60%
		//new Kultúra (Saját)
		//new ÉkszerészSzakma
    ];

    public override QualificationList FutureQualifications =>
    [
        new LanguageKnowledge(2, 3),
        new LanguageKnowledge(2, 3),
        new WoundHealing(level: 3),
        new ReadingAndWriting(QualificationLevel.Master, 4),
        new LanguageKnowledge(6, 4),
		//new Emberismeret MF 5
		new WoundHealing(QualificationLevel.Master, 5),
        new LegendKnowledge(QualificationLevel.Master, 6),
        new ProfessionKnowledge(Profession.Jeweler, QualificationLevel.Master, 8),
		//new DrágakőMágia(QualificationLevel.Master, 12)
	];

    public override List<PercentQualification> PercentQualifications => [];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new PriestKyrDisciplinesUsage(),
        new PriestMagic()
    ];

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(2)]
    public override byte GetPainToleranceModifier() => (byte)(DiceThrow._1K6() + 2);

    public override string ClassName => "Nastar Priest";
}
