﻿using MagusCharacterGenerator.GameSystem;
using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.FightMode;
using MagusCharacterGenerator.GameSystem.Qualifications;
using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Battle;
using MagusCharacterGenerator.Qualifications.Laical;
using MagusCharacterGenerator.Qualifications.Magic;
using MagusCharacterGenerator.Qualifications.Scientific;
using MagusCharacterGenerator.Qualifications.Scientific.Psi;
using System;
using System.Collections.Generic;

namespace MagusCharacterGenerator.Castes.Believer
{
    abstract class Paladin : Caste, ICaste, IHateRangedWeapons
    {
		public Paladin(byte level) : base(level) { }

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(8)]
		[SpecialTraining]
		public override short Strength => DiceThrow._1K10_Plus_8_Plus_SpecialTraining();

		[DiceThrow(ThrowType._3K6_2_Times)]
		public override short Speed => DiceThrow._3K6_2_Times();

		[DiceThrow(ThrowType._3K6_2_Times)]
		public override short Dexterity => DiceThrow._3K6_2_Times();

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(8)]
		public override short Stamina => DiceThrow._1K10_Plus_8();

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(10)]
		public override short Health => DiceThrow._1K10_Plus_10();

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(8)]
		public override short Beauty => DiceThrow._1K10_Plus_8();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public override short Intelligence => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(8)]
		public override short WillPower => DiceThrow._1K10_Plus_8();

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(12)]
		public override short Astral => DiceThrow._1K6_Plus_12();

		[DiceThrow(ThrowType._1K6)]
		public override short Gold => DiceThrow._1K6();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(8)]
		public override byte Bravery => (byte)(DiceThrow._2K6() + 8);

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(8)]
		public override byte Erudition => (byte)(DiceThrow._2K6() + 8);

		public override byte InitiatingBaseValue => 5;

        public override byte AttackingBaseValue => 20;

        public override byte DefendingBaseValue => 75;

        public override byte AimingBaseValue => throw new InvalidOperationException();

        public override byte FightValueModifier => 9;

        public override byte BaseQualificationPoints => 5;

        public override byte QualificationPointsModifier => 5;

        public override byte PercentQualificationModifier => 0;

        public override byte BaseLifePoints => 8;

        public override byte BasePainTolerancePoints => 7;

        public override bool AddFightValueOnFirstLevel => false;

        public override bool AddPainToleranceOnFirstLevel => false;

        public override bool AddQualificationPointsOnFirstLevel => true;

        public override QualificationList Qualifications => new QualificationList
        {
            new WeaponUsage(),
            new WeaponUsage(),
            new WeaponUsage(),
            new WeaponUsage(),
            new PsiPyarron(QualificationLevel.Master),
            new LanguageKnowledge(5),
            new LanguageKnowledge(4),
            new HeavyArmorWearing(),
            new ShieldUsing(),
            new Leadership(),
            new ReadingAndWriting(),
            new ReligionKnowledge(),
            new Etiquette(),
            new Heraldry(),
            new Riding(QualificationLevel.Master),
            new SingingAndMakingMusic(),
            new HistoryKnowledge()
       };

        public override QualificationList FutureQualifications => new QualificationList();

        public override List<PercentQualification> PercentQualifications => new List<PercentQualification>
        {
        };

        public override SpecialQualificationList SpecialQualifications => new SpecialQualificationList
        {
            new PriestMagic()
        };

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(5)]
		public override byte GetPainToleranceModifier() => (byte)(DiceThrow._1K6() + 5);
    }
}
