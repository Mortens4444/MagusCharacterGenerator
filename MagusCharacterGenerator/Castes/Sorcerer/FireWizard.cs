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
		public override short Strength => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._3K6_2_Times)]
		public override short Speed => DiceThrow._3K6_2_Times();

		[DiceThrow(ThrowType._3K6_2_Times)]
		public override short Dexterity => DiceThrow._3K6_2_Times();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public override short Stamina => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public override short Health => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._3K6)]
		public override short Beauty => DiceThrow._3K6();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public override short Intelligence => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public override short WillPower => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public override short Astral => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._3K6)]
		public override short Gold => DiceThrow._3K6();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(8)]
		public override byte Bravery => (byte)(DiceThrow._2K6() + 8);

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(8)]
		public override byte Erudition => (byte)(DiceThrow._2K6() + 8);

		public override byte InitiatingBaseValue => 6;

        public override byte AttackingBaseValue => 17;

        public override byte DefendingBaseValue => 72;

        public override byte AimingBaseValue => 0;

        public override byte FightValueModifier => 8;

        public override byte BaseQualificationPoints => 3;

        public override byte QualificationPointsModifier => 5;

        public override byte PercentQualificationModifier => 0;

        public override byte BaseLifePoints => 5;

        public override byte BasePainTolerancePoints => 4;

        public override bool AddFightValueOnFirstLevel => false;

        public override bool AddPainToleranceOnFirstLevel => false;

        public override bool AddQualificationPointsOnFirstLevel => true;

        public override QualificationList Qualifications => new QualificationList
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

        public override QualificationList FutureQualifications => new QualificationList();

        public override List<PercentQualification> PercentQualifications => new List<PercentQualification>
        {
        };

        public override SpecialQualificationList SpecialQualifications => new SpecialQualificationList
        {
            new FireWizardMagic()
        };

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(1)]
		public override byte GetPainToleranceModifier() => (byte)(DiceThrow._1K6() + 1);

        public override string ToString() => Lng.Elem("Fire wizard");
    }
}
