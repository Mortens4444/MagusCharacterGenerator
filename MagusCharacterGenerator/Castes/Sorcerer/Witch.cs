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
    class Witch : Caste, ICaste, ILikeMagic
    {
		public Witch(byte level = 1) : base(level) { }

		[DiceThrow(ThrowType._3K6)]
		public short Strength => DiceThrow._3K6();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public short Speed => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(8)]
		public short Dexterity => DiceThrow._1K10_Plus_8();

		[DiceThrow(ThrowType._3K6)]
		public short Stamina => DiceThrow._3K6();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public short Health => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(14)]
		public short Beauty => DiceThrow._1K6_Plus_14();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public short Intelligence => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public short WillPower => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(12)]
		public short Astral => DiceThrow._1K6_Plus_12_Plus_SpecialTraining();

		[DiceThrow(ThrowType._2K6)]
		public short Gold => DiceThrow._2K6();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(8)]
		public byte Bravery => (byte)(DiceThrow._2K6() + 8);

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(8)]
		public byte Erudition => (byte)(DiceThrow._2K6() + 8);

		public byte InitiatingBaseValue => 6;

        public byte AttackingBaseValue => 14;

        public byte DefendingBaseValue => 69;

        public byte AimingBaseValue => 0;

        public byte FightValueModifier => 4;

        public byte BaseQualificationPoints => 8;

        public byte QualificationPointsModifier => 12;

        public byte PercentQualificationModifier => 0;

        public byte BaseLifePoints => 3;

        public byte BasePainTolerancePoints => 1;

        public bool AddFightValueOnFirstLevel => false;

        public bool AddPainToleranceOnFirstLevel => false;

        public bool AddQualificationPointsOnFirstLevel => true;

        public QualificationList Qualifications => new QualificationList
        {
            new WeaponUsage(),
            new WeaponThrowing(),
            new PsiPyarron(QualificationLevel.Master),
            new LanguageKnowledge(3),
            new LanguageKnowledge(3),
            new Herbalism(),
            new ReadingAndWriting(),
            new PoisoningAndNeutralization(),
            new WoundHealing(),
            new SexualCulture()
       };

        public QualificationList FutureQualifications => new QualificationList
        {
            new PoisoningAndNeutralization(QualificationLevel.Master, 4),
            new Herbalism(QualificationLevel.Master, 5)
        };

        public List<PercentQualification> PercentQualifications => new List<PercentQualification>
        {
        };

        public SpecialQualificationList SpecialQualifications => new SpecialQualificationList
        {
            new WitchMagic()
        };

		[DiceThrow(ThrowType._1K6)]
		public byte GetPainToleranceModifier() => (byte)DiceThrow._1K6();

        public override string ToString()
        {
            return Lng.Elem("Witch");
        }
    }
}
