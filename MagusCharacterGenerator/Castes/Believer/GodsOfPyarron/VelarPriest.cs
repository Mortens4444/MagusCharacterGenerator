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
	/// <summary>
	/// Velar = Kyel
	/// https://nemaakos.files.wordpress.com/2015/12/velar.pdf
	/// </summary>
	class VelarPriest : Caste, ICaste, ILikeMagic
    {
		public VelarPriest(byte level) : base(level) { }

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

		public override byte InitiatingBaseValue => 5;

        public override byte AttackingBaseValue => 17;

        public override byte DefendingBaseValue => 75;

        public override byte AimingBaseValue => 0;

        public override byte FightValueModifier => 8;

        public override byte BaseQualificationPoints => 6;

        public override byte QualificationPointsModifier => 9;

        public override byte PercentQualificationModifier => 0;

        public override byte BaseLifePoints => 6;

        public override byte BasePainTolerancePoints => 6;

        public override bool AddFightValueOnFirstLevel => false;

        public override bool AddPainToleranceOnFirstLevel => false;

        public override bool AddQualificationPointsOnFirstLevel => true;

        public override QualificationList Qualifications => new QualificationList
        {
            new WeaponUsage(),
            new WeaponUsage(),
            new LanguageKnowledge(4),
			new Etiquette(),
			new PsiPyarron(QualificationLevel.Master),
            new ReadingAndWriting(),
			new WoundHealing(),
			new ReligionKnowledge(QualificationLevel.Master),
            new HistoryKnowledge(),
            new SingingAndMakingMusic(),

			// TODO
			//new Emberismeret()
			//new Erkölcs(QualificationLevel.Master),
			//new Helyismeret 60%
			//new Kultúra (QualificationLevel.Master) //Saját
			//new Politika/Diplomácia()
       };

        public override QualificationList FutureQualifications => new QualificationList
		{
			//new Balzsamozás(level: 2)
			//new Jog/Törvénykezés(level: 2)
            new HistoryKnowledge(QualificationLevel.Master, 3),
			new ReadingAndWriting(QualificationLevel.Master, 4),
			//new Emberismeret(QualificationLevel.Master, 5)
			//new Balzsamozás(QualificationLevel.Master, 6)
		};

        public override List<PercentQualification> PercentQualifications => new List<PercentQualification>
        {
        };

        public override SpecialQualificationList SpecialQualifications => new SpecialQualificationList
        {
            new PriestKyrDisciplinesUsage(),
            new PriestMagic()
        };

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(3)]
		public override byte GetPainToleranceModifier() => (byte)(DiceThrow._1K6() + 3);

		public override string ToString() => Lng.Elem("Velar priest");
	}
}
