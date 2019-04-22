using MagusCharacterGenerator.GameSystem;
using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.FightMode;
using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Battle;
using MagusCharacterGenerator.Qualifications.Laical;
using MagusCharacterGenerator.Qualifications.Percentages;
using Mtf.Languages;
using System.Collections.Generic;

namespace MagusCharacterGenerator.Castes.Fighter
{
	class Warrior : Caste, ICaste, IJustFight
	{
		public Warrior(byte level = 1) : base(level) { }

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(12)]
		[SpecialTraining]
		public short Strength => DiceThrow._1K6_Plus_12_Plus_SpecialTraining();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		[SpecialTraining]
		public short Speed => DiceThrow._2K6_Plus_6_Plus_SpecialTraining();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		[SpecialTraining]
		public short Dexterity => DiceThrow._2K6_Plus_6_Plus_SpecialTraining();

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(8)]
		[SpecialTraining]
		public short Stamina => DiceThrow._1K10_Plus_8_Plus_SpecialTraining();

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(10)]
		public short Health => DiceThrow._1K10_Plus_10();

		[DiceThrow(ThrowType._3K6_2_Times)]
		public short Beauty => DiceThrow._3K6_2_Times();

		[DiceThrow(ThrowType._3K6_2_Times)]
		public short Intelligence => DiceThrow._3K6_2_Times();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public short WillPower => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._3K6_2_Times)]
		public short Astral => DiceThrow._3K6_2_Times();

		[DiceThrow(ThrowType._3K6)]
		public short Gold => DiceThrow._3K6();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(8)]
		public byte Bravery => (byte)(DiceThrow._2K6() + 8);

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(8)]
		public byte Erudition => (byte)(DiceThrow._2K6() + 8);

		public byte InitiatingBaseValue => 9;

        public byte AttackingBaseValue => 20;

        public byte DefendingBaseValue => 75;

        public byte AimingBaseValue => 0;

        public byte FightValueModifier => 11;

        public byte BaseQualificationPoints => 10;

        public byte QualificationPointsModifier => 14;

        public byte PercentQualificationModifier => 0;

        public byte BaseLifePoints => 7;

        public byte BasePainTolerancePoints => 6;

        public bool AddFightValueOnFirstLevel => true;

        public bool AddPainToleranceOnFirstLevel => true;

        public bool AddQualificationPointsOnFirstLevel => true;

        public QualificationList Qualifications => new QualificationList
        {
            new WeaponUsage(),
            new WeaponUsage(),
            new WeaponUsage(),
            new Riding(),
            new Swimming(),
            new Running()
        };

        public QualificationList FutureQualifications => new QualificationList
        {
            new Leadership(level: 6)
        };

        public List<PercentQualification> PercentQualifications => new List<PercentQualification>
        {
            new Climbing(15),
            new Falling(20),
            new Jumping(10)
        };

        public SpecialQualificationList SpecialQualifications => new SpecialQualificationList
        {
        };

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(4)]
		public byte GetPainToleranceModifier() => (byte)(DiceThrow._1K6() + 4);

        public override string ToString() => Lng.Elem("Warrior");
    }
}
