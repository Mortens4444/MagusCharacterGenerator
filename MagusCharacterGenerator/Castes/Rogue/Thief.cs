﻿using MagusCharacterGenerator.GameSystem;
using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.FightMode;
using MagusCharacterGenerator.GameSystem.Qualifications;
using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Battle;
using MagusCharacterGenerator.Qualifications.Laical;
using MagusCharacterGenerator.Qualifications.Percentages;
using MagusCharacterGenerator.Qualifications.Scientific;
using MagusCharacterGenerator.Qualifications.Specialities;
using MagusCharacterGenerator.Qualifications.Underworld;
using Mtf.Languages;
using System.Collections.Generic;

namespace MagusCharacterGenerator.Castes.Rogue
{
    class Thief : Caste, ICaste, IJustFight
	{
		public Thief(byte level = 1) : base(level) { }

		[DiceThrow(ThrowType._3K6_2_Times)]
		public override short Strength => DiceThrow._3K6_2_Times();

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(8)]
		[SpecialTraining]
		public override short Speed => DiceThrow._1K10_Plus_8_Plus_SpecialTraining();

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(12)]
		[SpecialTraining]
		public override short Dexterity => DiceThrow._1K6_Plus_12_Plus_SpecialTraining();

		[DiceThrow(ThrowType._3K6_2_Times)]
		public override short Stamina => DiceThrow._3K6_2_Times();

		[DiceThrow(ThrowType._3K6_2_Times)]
		public override short Health => DiceThrow._3K6_2_Times();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public override short Beauty => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public override short Intelligence => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._3K6)]
		public override short WillPower => DiceThrow._3K6();

		[DiceThrow(ThrowType._3K6_2_Times)]
		public override short Astral => DiceThrow._3K6_2_Times();

		[DiceThrow(ThrowType._1K10)]
		public override short Gold => DiceThrow._1K10();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(8)]
		public override byte Bravery => (byte)(DiceThrow._2K6() + 8);

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(8)]
		public override byte Erudition => (byte)(DiceThrow._2K6() + 8);

		public override byte InitiatingBaseValue => 8;

        public override byte AttackingBaseValue => 17;

        public override byte DefendingBaseValue => 72;

        public override byte AimingBaseValue => 10;

        public override byte FightValueModifier => 6;

        public override byte BaseQualificationPoints => 8;

        public override byte QualificationPointsModifier => 10;

        public override byte PercentQualificationModifier => 62;

        public override byte BaseLifePoints => 4;

        public override byte BasePainTolerancePoints => 5;

        public override bool AddFightValueOnFirstLevel => false;

        public override bool AddPainToleranceOnFirstLevel => false;

        public override bool AddQualificationPointsOnFirstLevel => true;

        public override QualificationList Qualifications => new QualificationList
        {
            new WeaponUsage(),
            new WeaponUsage(),
            new WeaponThrowing(),
            new LanguageKnowledge(3),
            new LanguageKnowledge(2),
            new LanguageKnowledge(2),
            new ValueEstimation(),
            new PubFighting()
        };

        public override QualificationList FutureQualifications => new QualificationList
        {
            new FreeFromBondage(level: 2),
            new Knotting(level: 3),
            new Backstab(level: 3),
            new PubFighting(QualificationLevel.Master, 4),
            new WeaponThrowing(QualificationLevel.Master, 5)
        };

        public override List<PercentQualification> PercentQualifications => new List<PercentQualification>
        {
            new Climbing(45),
            new Falling(15),
            new Jumping(10),
            new LockPicking(25),
            new Sneaking(30),
            new Stealth(15),
            new Tightrope(25),
            new PickPocketing(25),
            new TrapDetect(25),
            new SecretDoorSearching(15),
        };

        public override SpecialQualificationList SpecialQualifications => new SpecialQualificationList
        {
            new ThiefInitiatingValueIncreasing()
        };

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(3)]
		public override byte GetPainToleranceModifier() => (byte)(DiceThrow._1K6() + 3);

        public override string ToString() => Lng.Elem("Thief");
    }
}
