using MagusCharacterGenerator.GameSystem;
using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.FightMode;
using MagusCharacterGenerator.GameSystem.Qualifications;
using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Battle;
using MagusCharacterGenerator.Qualifications.Laical;
using MagusCharacterGenerator.Qualifications.Magic;
using MagusCharacterGenerator.Qualifications.Scientific;
using MagusCharacterGenerator.Qualifications.Scientific.Psi;
using Mtf.Languages;
using System.Collections.Generic;

namespace MagusCharacterGenerator.Castes.Sorcerer
{
    class FireWizard : Caste, ICaste, ILikeMagic
	{
		public FireWizard(byte level = 1) : base(level) { }

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public short Strength => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._3K6_2_Times)]
		public short Speed => DiceThrow._3K6_2_Times();

		[DiceThrow(ThrowType._3K6_2_Times)]
		public short Dexterity => DiceThrow._3K6_2_Times();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public short Stamina => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public short Health => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._3K6)]
		public short Beauty => DiceThrow._3K6();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public short Intelligence => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public short WillPower => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public short Astral => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._3K6)]
		public short Gold => DiceThrow._3K6();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(8)]
		public byte Bravery => (byte)(DiceThrow._2K6() + 8);

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(8)]
		public byte Erudition => (byte)(DiceThrow._2K6() + 8);

		public byte InitiatingBaseValue => 6;

        public byte AttackingBaseValue => 17;

        public byte DefendingBaseValue => 72;

        public byte AimingBaseValue => 0;

        public byte FightValueModifier => 8;

        public byte BaseQualificationPoints => 3;

        public byte QualificationPointsModifier => 5;

        public byte PercentQualificationModifier => 0;

        public byte BaseLifePoints => 5;

        public byte BasePainTolerancePoints => 4;

        public bool AddFightValueOnFirstLevel => false;

        public bool AddPainToleranceOnFirstLevel => false;

        public bool AddQualificationPointsOnFirstLevel => true;

        public QualificationList Qualifications => new QualificationList
        {
            new WeaponUsage(),
            new WeaponUsage(),
            new PsiPyarron(QualificationLevel.Master),
            new LanguageKnowledge(4),
            new LanguageKnowledge(3),
            new ReadingAndWriting(),
            new Riding(),
            new Sailing()
       };

        public QualificationList FutureQualifications => new QualificationList();

        public List<PercentQualification> PercentQualifications => new List<PercentQualification>
        {
        };

        public SpecialQualificationList SpecialQualifications => new SpecialQualificationList
        {
            new FireWizardMagic()
        };

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(1)]
		public byte GetPainToleranceModifier() => (byte)(DiceThrow._1K6() + 1);

        public override string ToString() => Lng.Elem("Fire wizard");
    }
}
