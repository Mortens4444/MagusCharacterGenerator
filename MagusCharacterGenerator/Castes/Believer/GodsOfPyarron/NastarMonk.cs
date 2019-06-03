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
		public override short Strength => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._3K6_2_Times)]
		public override short Speed => DiceThrow._3K6_2_Times();

		[DiceThrow(ThrowType._3K6_2_Times)]
		public override short Dexterity => DiceThrow._3K6_2_Times();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public override short Stamina => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(8)]
		public override short Health => DiceThrow._1K10_Plus_8();

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(10)]
		public override short Beauty => DiceThrow._1K10_Plus_10();

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(8)]
		public override short Intelligence => DiceThrow._1K10_Plus_8();

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(8)]
		[SpecialTraining]
		public override short WillPower => DiceThrow._1K10_Plus_8_Plus_SpecialTraining();

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(12)]
		[SpecialTraining]
		public override short Astral => DiceThrow._1K6_Plus_12_Plus_SpecialTraining();

		[DiceThrow(ThrowType._1K6)]
		public override short Gold => DiceThrow._1K6();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(8)]
		public override byte Bravery => (byte)(DiceThrow._2K6() + 8);

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(8)]
		public override byte Erudition => (byte)(DiceThrow._2K6() + 8);

		public override byte InitiatingBaseValue => 4;

        public override byte AttackingBaseValue => 14;

        public override byte DefendingBaseValue => 75;

        public override byte AimingBaseValue => 0;

        public override byte FightValueModifier => 7;

        public override byte BaseQualificationPoints => 5;

        public override byte QualificationPointsModifier => 8;

        public override byte PercentQualificationModifier => 0;

        public override byte BaseLifePoints => 4;

        public override byte BasePainTolerancePoints => 8;

        public override bool AddFightValueOnFirstLevel => false;

        public override bool AddPainToleranceOnFirstLevel => false;

        public override bool AddQualificationPointsOnFirstLevel => true;

        public override QualificationList Qualifications => new QualificationList
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

        public override QualificationList FutureQualifications => new QualificationList
		{
			//new Emberismeret MF 3
			new ReadingAndWriting(QualificationLevel.Master, 4),
			new Herbalism(level: 5),
			new AntientLanguageKnowledge(level: 5),
			new Demonology(level: 6),
			new AntientLanguageKnowledge(QualificationLevel.Master, 7)
		};

        public override List<PercentQualification> PercentQualifications => new List<PercentQualification>
        {
        };

        public override SpecialQualificationList SpecialQualifications => new SpecialQualificationList
        {
            new PriestKyrDisciplinesUsage(),
            new PriestMagic(),
			new SlanDisciplinesUsage()
		};

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(5)]
		public override byte GetPainToleranceModifier() => (byte)(DiceThrow._1K6() + 5);

		public override string ToString() => Lng.Elem("Nastar monk");
	}
}
