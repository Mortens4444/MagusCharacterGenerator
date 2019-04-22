﻿using MagusCharacterGenerator.GameSystem;
using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Battle;
using MagusCharacterGenerator.Qualifications.Scientific;
using Mtf.Languages;
using System.Collections.Generic;

namespace MagusCharacterGenerator.Castes.Sorcerer
{
	class Soldier : Caste, ICaste
    {
		public Soldier(byte level = 1) : base(level) { }

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public short Strength => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public short Speed => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public short Dexterity => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public short Stamina => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public short Health => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._2K6)]
		public short Beauty => DiceThrow._2K6();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public short Intelligence => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public short WillPower => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._2K6)]
		public short Astral => DiceThrow._2K6();

		[DiceThrow(ThrowType._1K10)]
		public short Gold => DiceThrow._1K10();

		[DiceThrow(ThrowType._3K6)]
		public byte Bravery => (byte)DiceThrow._3K6();

		[DiceThrow(ThrowType._2K6)]
		public byte Erudition => (byte)DiceThrow._2K6();

		public byte InitiatingBaseValue => 10;

        public byte AttackingBaseValue => 25;

        public byte DefendingBaseValue => 75;

        public byte AimingBaseValue => 0;

        public byte FightValueModifier => 7;

        public byte BaseQualificationPoints => 0;

        public byte QualificationPointsModifier => 1;

        public byte PercentQualificationModifier => 0;

        public byte BaseLifePoints => 5;

        public byte BasePainTolerancePoints => 15;

        public bool AddFightValueOnFirstLevel => false;

        public bool AddPainToleranceOnFirstLevel => false;

        public bool AddQualificationPointsOnFirstLevel => false;

        public QualificationList Qualifications => new QualificationList
        {
            new WeaponUsage(),
			new WeaponUsage(),
			new HeavyArmorWearing(),
			new ShieldUsing(),
			new Leadership(),
			new ReadingAndWriting()
       };

        public QualificationList FutureQualifications => new QualificationList
        {
        };

        public List<PercentQualification> PercentQualifications => new List<PercentQualification>
        {
        };

        public SpecialQualificationList SpecialQualifications => new SpecialQualificationList
        {
        };

		[DiceThrow(ThrowType._1K5)]
		[DiceThrowModifier(8)]
		public byte GetPainToleranceModifier() => (byte)DiceThrow._1K5();

        public override string ToString()
        {
            return Lng.Elem("Soldier");
        }
    }
}
