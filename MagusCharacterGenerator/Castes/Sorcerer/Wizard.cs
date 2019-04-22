using MagusCharacterGenerator.GameSystem;
using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.FightMode;
using MagusCharacterGenerator.GameSystem.Qualifications;
using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Battle;
using MagusCharacterGenerator.Qualifications.Magic;
using MagusCharacterGenerator.Qualifications.Scientific;
using MagusCharacterGenerator.Qualifications.Scientific.Psi;
using Mtf.Languages;
using System.Collections.Generic;

namespace MagusCharacterGenerator.Castes.Sorcerer
{
    class Wizard : Caste, ICaste, ILikeMagic
	{
		public Wizard(byte level = 1) : base(level) { }

		[DiceThrow(ThrowType._3K6)]
		public short Strength => DiceThrow._3K6();

		[DiceThrow(ThrowType._3K6_2_Times)]
		public short Speed => DiceThrow._3K6_2_Times();

		[DiceThrow(ThrowType._3K6_2_Times)]
		public short Dexterity => DiceThrow._3K6_2_Times();

		[DiceThrow(ThrowType._3K6)]
		public short Stamina => DiceThrow._3K6();

		[DiceThrow(ThrowType._3K6_2_Times)]
		public short Health => DiceThrow._3K6_2_Times();

		[DiceThrow(ThrowType._3K6)]
		public short Beauty => DiceThrow._3K6();

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(12)]
		[SpecialTraining]
		public short Intelligence => DiceThrow._1K6_Plus_12_Plus_SpecialTraining();

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(12)]
		[SpecialTraining]
		public short WillPower => DiceThrow._1K6_Plus_12_Plus_SpecialTraining();

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(12)]
		[SpecialTraining]
		public short Astral => DiceThrow._1K6_Plus_12_Plus_SpecialTraining();

		[DiceThrow(ThrowType._3K6)]
		public short Gold => DiceThrow._3K6();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(8)]
		public byte Bravery => (byte)(DiceThrow._2K6() + 8);

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(8)]
		public byte Erudition => (byte)(DiceThrow._2K6() + 8);

		public byte InitiatingBaseValue => 2;

        public byte AttackingBaseValue => 15;

        public byte DefendingBaseValue => 70;

        public byte AimingBaseValue => 0;

        public byte FightValueModifier => 4;

        public byte BaseQualificationPoints => 7;

        public byte QualificationPointsModifier => 7;

        public byte PercentQualificationModifier => 0;

        public byte BaseLifePoints => 3;

        public byte BasePainTolerancePoints => 2;

        public bool AddFightValueOnFirstLevel => false;

        public bool AddPainToleranceOnFirstLevel => false;

        public bool AddQualificationPointsOnFirstLevel => true;

        public QualificationList Qualifications => new QualificationList
        {
            new WeaponUsage(),
            new PsiKyrMethod(),
            new LanguageKnowledge(5),
            new LanguageKnowledge(4),
            new ReadingAndWriting(),
            new Alchemy(),
            new AntientLanguageKnowledge(),
            new WoundHealing(),
            new Physiology(),
            new LegendKnowledge(),
            new HistoryKnowledge(),
            new RuneMagic()
       };

        public QualificationList FutureQualifications => new QualificationList
        {
            new Herbalism(level: 4),
            new Alchemy(QualificationLevel.Master, 6),
            new RuneMagic(QualificationLevel.Master, 6),
            new LegendKnowledge(QualificationLevel.Master, 7),
            new HistoryKnowledge(QualificationLevel.Master, 8)
        };

        public List<PercentQualification> PercentQualifications => new List<PercentQualification>
        {
        };

        public SpecialQualificationList SpecialQualifications => new SpecialQualificationList
        {
            new WizardMagic()
        };

		[DiceThrow(ThrowType._1K6)]
		public byte GetPainToleranceModifier() => (byte)DiceThrow._1K6();

        public override string ToString()
        {
            return Lng.Elem("Wizard");
        }
    }
}
