using MagusCharacterGenerator.GameSystem;
using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Laical;
using MagusCharacterGenerator.Qualifications.Scientific;
using Mtf.Languages;
using System.Collections.Generic;

namespace MagusCharacterGenerator.Castes.Sorcerer
{
	class Merchant : Caste, ICaste
    {
		public Merchant(byte level = 1) : base(level) { }

		[DiceThrow(ThrowType._2K6)]
		public override short Strength => DiceThrow._2K6();

		[DiceThrow(ThrowType._2K6)]
		public override short Speed => DiceThrow._2K6();

		[DiceThrow(ThrowType._2K6)]
		public override short Dexterity => DiceThrow._2K6();

		[DiceThrow(ThrowType._1K10)]
		public override short Stamina => DiceThrow._1K10();

		[DiceThrow(ThrowType._2K6)]
		public override short Health => DiceThrow._2K6();

		[DiceThrow(ThrowType._2K6)]
		public override short Beauty => DiceThrow._2K6();

		[DiceThrow(ThrowType._2K6)]
		public override short Intelligence => DiceThrow._2K6();

		[DiceThrow(ThrowType._2K6)]
		public override short WillPower => DiceThrow._2K6();

		[DiceThrow(ThrowType._2K6)]
		public override short Astral => DiceThrow._2K6();

		[DiceThrow(ThrowType._1K100)]
		public override short Gold => DiceThrow._1K100();

		[DiceThrow(ThrowType._1K6)]
		public override byte Bravery => (byte)DiceThrow._1K6();

		[DiceThrow(ThrowType._2K6)]
		public override byte Erudition => (byte)DiceThrow._2K6();

		public override byte InitiatingBaseValue => 1;

        public override byte AttackingBaseValue => 5;

        public override byte DefendingBaseValue => 50;

        public override byte AimingBaseValue => 0;

        public override byte FightValueModifier => 4;

        public override byte BaseQualificationPoints => 0;

        public override byte QualificationPointsModifier => 0;

        public override byte PercentQualificationModifier => 0;

        public override byte BaseLifePoints => 3;

        public override byte BasePainTolerancePoints => 10;

        public override bool AddFightValueOnFirstLevel => false;

        public override bool AddPainToleranceOnFirstLevel => false;

        public override bool AddQualificationPointsOnFirstLevel => false;

        public override QualificationList Qualifications => new QualificationList
        {
            new ValueEstimation(),
			new NewsDistributor()
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

		[DiceThrow(ThrowType._1K2)]
		public override byte GetPainToleranceModifier() => (byte)DiceThrow._1K2();

        public override string ToString()
        {
            return Lng.Elem("Merchant");
        }
    }
}
