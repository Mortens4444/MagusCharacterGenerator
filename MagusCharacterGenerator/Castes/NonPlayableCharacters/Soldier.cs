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
		public override short Strength => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public override short Speed => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public override short Dexterity => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public override short Stamina => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public override short Health => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._2K6)]
		public override short Beauty => DiceThrow._2K6();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public override short Intelligence => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public override short WillPower => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._2K6)]
		public override short Astral => DiceThrow._2K6();

		[DiceThrow(ThrowType._1K10)]
		public override short Gold => DiceThrow._1K10();

		[DiceThrow(ThrowType._3K6)]
		public override byte Bravery => (byte)DiceThrow._3K6();

		[DiceThrow(ThrowType._2K6)]
		public override byte Erudition => (byte)DiceThrow._2K6();

		public override byte InitiatingBaseValue => 10;

        public override byte AttackingBaseValue => 25;

        public override byte DefendingBaseValue => 75;

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

        public override QualificationList Qualifications => new QualificationList
        {
            new WeaponUsage(),
			new WeaponUsage(),
			new HeavyArmorWearing(),
			new ShieldUsing(),
			new Leadership(),
			new ReadingAndWriting()
       };

        public override QualificationList FutureQualifications => new QualificationList
        {
        };

        public override List<PercentQualification> PercentQualifications => new List<PercentQualification>
        {
        };

        public override SpecialQualificationList SpecialQualifications => new SpecialQualificationList
        {
        };

		[DiceThrow(ThrowType._1K5)]
		[DiceThrowModifier(8)]
		public override byte GetPainToleranceModifier() => (byte)DiceThrow._1K5();

        public override string ToString()
        {
            return Lng.Elem("Soldier");
        }
    }
}
