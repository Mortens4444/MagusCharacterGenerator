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
using MagusCharacterGenerator.Qualifications.Specialities;
using Mtf.Languages;
using System.Collections.Generic;

namespace MagusCharacterGenerator.Castes.Believer
{
	class NastarMonk : Caste, ICaste, ILikeMagic
    {
		public NastarMonk(byte level) : base(level) { }

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

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(8)]
		public short Health => DiceThrow._1K10_Plus_8();

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(10)]
		public short Beauty => DiceThrow._1K10_Plus_10();

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(8)]
		public short Intelligence => DiceThrow._1K10_Plus_8();

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(8)]
		[SpecialTraining]
		public short WillPower => DiceThrow._1K10_Plus_8_Plus_SpecialTraining();

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(12)]
		[SpecialTraining]
		public short Astral => DiceThrow._1K6_Plus_12_Plus_SpecialTraining();

		[DiceThrow(ThrowType._1K6)]
		public short Gold => DiceThrow._1K6();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(8)]
		public byte Bravery => (byte)(DiceThrow._2K6() + 8);

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(8)]
		public byte Erudition => (byte)(DiceThrow._2K6() + 8);

		public byte InitiatingBaseValue => 4;

        public byte AttackingBaseValue => 14;

        public byte DefendingBaseValue => 75;

        public byte AimingBaseValue => 0;

        public byte FightValueModifier => 7;

        public byte BaseQualificationPoints => 5;

        public byte QualificationPointsModifier => 8;

        public byte PercentQualificationModifier => 0;

        public byte BaseLifePoints => 4;

        public byte BasePainTolerancePoints => 8;

        public bool AddFightValueOnFirstLevel => false;

        public bool AddPainToleranceOnFirstLevel => false;

        public bool AddQualificationPointsOnFirstLevel => true;

        public QualificationList Qualifications => new QualificationList
        {
            new WeaponUsage(),
            new PsiPyarron(QualificationLevel.Master),
            new LanguageKnowledge(5),
            new LanguageKnowledge(5),
            new LanguageKnowledge(5),
			new Physiology(),
            new ReadingAndWriting(),
            new WoundHealing(),
			new ReligionKnowledge(),

			// TODO
			//new Emberismeret
			//new Erkölcs(QualificationLevel.Master),
			//new Helyismeret 60%
			//new Kultúra(QualificationLevel.Master), Saját
			//new KínzásElviselése()
       };

        public QualificationList FutureQualifications => new QualificationList
		{
			//new Emberismeret MF 3
			new ReadingAndWriting(QualificationLevel.Master, 4),
			new Herbalism(level: 5),
			new AntientLanguageKnowledge(level: 5),
			new Demonology(level: 6),
			new AntientLanguageKnowledge(QualificationLevel.Master, 7)
		};

        public List<PercentQualification> PercentQualifications => new List<PercentQualification>
        {
        };

        public SpecialQualificationList SpecialQualifications => new SpecialQualificationList
        {
            new PriestKyrDisciplinesUsage(),
            new PriestMagic(),
			new SlanDisciplinesUsage()
		};

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(5)]
		public byte GetPainToleranceModifier() => (byte)(DiceThrow._1K6() + 5);

		public override string ToString() => Lng.Elem("Nastar monk");
	}
}
