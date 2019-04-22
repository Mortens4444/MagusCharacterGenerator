﻿using MagusCharacterGenerator.GameSystem;
using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.FightMode;
using MagusCharacterGenerator.GameSystem.Qualifications;
using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Battle;
using MagusCharacterGenerator.Qualifications.Laical;
using MagusCharacterGenerator.Qualifications.Percentages;
using MagusCharacterGenerator.Qualifications.Scientific.Psi;
using MagusCharacterGenerator.Qualifications.Specialities;
using MagusCharacterGenerator.Qualifications.Underworld;
using Mtf.Languages;
using System.Collections.Generic;

namespace MagusCharacterGenerator.Castes.Fighter
{
    class Headhunter : Caste, ICaste, IJustFight
	{
		public Headhunter(byte level = 1) : base(level) { }

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public short Strength => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(12)]
		[SpecialTraining]
		public short Speed => DiceThrow._1K6_Plus_12_Plus_SpecialTraining();

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(8)]
		public short Dexterity => DiceThrow._1K10_Plus_8();

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(12)]
		[SpecialTraining]
		public short Stamina => DiceThrow._1K6_Plus_12_Plus_SpecialTraining();

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(10)]
		public short Health => DiceThrow._1K10_Plus_10();

		[DiceThrow(ThrowType._3K6)]
		public short Beauty => DiceThrow._3K6();

		[DiceThrow(ThrowType._3K6_2_Times)]
		public short Intelligence => DiceThrow._3K6_2_Times();

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(8)]
		public short WillPower => DiceThrow._1K10_Plus_8();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public short Astral => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._1K6)]
		public short Gold => DiceThrow._1K6();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(8)]
		public byte Bravery => (byte)(DiceThrow._2K6() + 8);

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(8)]
		public byte Erudition => (byte)(DiceThrow._2K6() + 8);

		public byte InitiatingBaseValue => 10;

        public byte AttackingBaseValue => 20;

        public byte DefendingBaseValue => 75;

        public byte AimingBaseValue => 0;

        public byte FightValueModifier => 11;

        public byte BaseQualificationPoints => 3;

        public byte QualificationPointsModifier => 5;

        public byte PercentQualificationModifier => 20;

        public byte BaseLifePoints => 6;

        public byte BasePainTolerancePoints => 7;

        public bool AddFightValueOnFirstLevel => false;

        public bool AddPainToleranceOnFirstLevel => false;

        public bool AddQualificationPointsOnFirstLevel => true;

        public QualificationList Qualifications => new QualificationList
        {
            new WeaponUsage(),
            new WeaponUsage(),
            new WeaponUsage(),
            new WeaponUsage(),
            new WeaponUsage(),
            new WeaponUsage(),
            new WeaponUsage(),
            new WeaponUsage(),
            new WeaponUsage(),
            new WeaponThrowing(),
            new WeaponThrowing(),
            new WeaponThrowing(),
            new FreeFromBondage(),
            new PsiPyarron(),
            new Swimming(),
            new Running(),
            new CamouflageOrDisguise(),
            new Backstab()
        };

        public QualificationList FutureQualifications => new QualificationList
        {
            new FreeFromBondage(level: 2),
            new FreeFromBondage(QualificationLevel.Master, 2),
            new BlindFighting(level: 3),
            new TrackReadingAndHiding(level: 4),
            new CamouflageOrDisguise(QualificationLevel.Master, 4),
            new PsiPyarron(QualificationLevel.Master, 5),
            new BlindFighting(QualificationLevel.Master, 7),
            new FreeFromBondage(QualificationLevel.Master, 8),
            new TrackReadingAndHiding(QualificationLevel.Master, 9)
        };

        public List<PercentQualification> PercentQualifications => new List<PercentQualification>
        {
            new Climbing(30),
            new Falling(15),
            new Jumping(15),
            new Sneaking(20),
            new Stealth(25),
            new TrapDetect(10)
        };

        public SpecialQualificationList SpecialQualifications => new SpecialQualificationList
        {
            new HeadHunterDamageIncreasing(),
            new SlanDisciplinesUsage(),
            new HeadHunterUnknownWeaponUsage(),
            new HeadHunterInitiatingValueIncreasing()
        };

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(5)]
		public byte GetPainToleranceModifier() => (byte)(DiceThrow._1K6() + 5);

        public override string ToString() => Lng.Elem("Headhunter");
    }
}
