using MagusCharacterGenerator.GameSystem;
using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Battle;
using MagusCharacterGenerator.Qualifications.Scientific;
using Mtf.Languages;
using System.Collections.Generic;

namespace MagusCharacterGenerator.Castes.Sorcerer
{
	class Noble : Caste, ICaste
    {
		public Noble(byte level = 1) : base(level) { }

		[DiceThrow(ThrowType._1K10)]
		public short Strength => DiceThrow._1K10();

		[DiceThrow(ThrowType._1K10)]
		public short Speed => DiceThrow._1K10();

		[DiceThrow(ThrowType._1K10)]
		public short Dexterity => DiceThrow._1K10();

		[DiceThrow(ThrowType._1K10)]
		public short Stamina => DiceThrow._1K10();

		[DiceThrow(ThrowType._2K6)]
		public short Health => DiceThrow._2K6();

		[DiceThrow(ThrowType._2K6)]
		public short Beauty => DiceThrow._2K6();

		[DiceThrow(ThrowType._2K6)]
		public short Intelligence => DiceThrow._2K6();

		[DiceThrow(ThrowType._2K6)]
		public short WillPower => DiceThrow._2K6();

		[DiceThrow(ThrowType._2K6)]
		public short Astral => DiceThrow._2K6();

		[DiceThrow(ThrowType._3K100)]
		public short Gold => DiceThrow._3K100();

		[DiceThrow(ThrowType._1K6)]
		public byte Bravery => (byte)DiceThrow._1K6();

		[DiceThrow(ThrowType._1K6)]
		public byte Erudition => (byte)DiceThrow._1K6();

		public byte InitiatingBaseValue => 1;

        public byte AttackingBaseValue => 5;

        public byte DefendingBaseValue => 50;

        public byte AimingBaseValue => 0;

        public byte FightValueModifier => 4;

        public byte BaseQualificationPoints => 0;

        public byte QualificationPointsModifier => 0;

        public byte PercentQualificationModifier => 0;

        public byte BaseLifePoints => 3;

        public byte BasePainTolerancePoints => 10;

        public bool AddFightValueOnFirstLevel => false;

        public bool AddPainToleranceOnFirstLevel => false;

        public bool AddQualificationPointsOnFirstLevel => false;

        public QualificationList Qualifications => new QualificationList
        {
            new WeaponUsage(),
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

		[DiceThrow(ThrowType._1K2)]
		public byte GetPainToleranceModifier() => (byte)DiceThrow._1K2();

        public override string ToString()
        {
            return Lng.Elem("Noble");
        }
    }
}
