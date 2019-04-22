using MagusCharacterGenerator.GameSystem;
using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.FightMode;
using MagusCharacterGenerator.GameSystem.Qualifications;
using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Battle;
using MagusCharacterGenerator.Qualifications.Laical;
using MagusCharacterGenerator.Qualifications.Magic;
using MagusCharacterGenerator.Qualifications.Percentages;
using MagusCharacterGenerator.Qualifications.Scientific;
using MagusCharacterGenerator.Qualifications.Scientific.Psi;
using MagusCharacterGenerator.Qualifications.Specialities;
using MagusCharacterGenerator.Qualifications.Underworld;
using Mtf.Languages;
using System.Collections.Generic;

namespace MagusCharacterGenerator.Castes.Rogue
{
    class Bard : Caste, ICaste, IJustFight
	{
		public Bard(byte level = 1) : base(level) { }

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(8)]
		public short Strength => DiceThrow._1K10_Plus_8();

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(8)]
		[SpecialTraining]
		public short Speed => DiceThrow._1K10_Plus_8_Plus_SpecialTraining();

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(8)]
		public short Dexterity => DiceThrow._1K10_Plus_8();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public short Stamina => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public short Health => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(12)]
		[SpecialTraining]
		public short Beauty => DiceThrow._1K6_Plus_12_Plus_SpecialTraining();

		[DiceThrow(ThrowType._1K10_2_Times)]
		[DiceThrowModifier(8)]
		public short Intelligence => DiceThrow._1K10_Plus_8_2_Times();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public short WillPower => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(8)]
		public short Astral => DiceThrow._1K10_Plus_8();

		[DiceThrow(ThrowType._1K10)]
		public short Gold => DiceThrow._1K10();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(8)]
		public byte Bravery => (byte)(DiceThrow._2K6() + 8);

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(8)]
		public byte Erudition => (byte)(DiceThrow._2K6() + 8);

		public byte InitiatingBaseValue => 10;

        public byte AttackingBaseValue => 20;

        public byte DefendingBaseValue => 75;

        public byte AimingBaseValue => 10;

        public byte FightValueModifier => 9;

        public byte BaseQualificationPoints => 4;

        public byte QualificationPointsModifier => 6;

        public byte PercentQualificationModifier => 45;

        public byte BaseLifePoints => 5;

        public byte BasePainTolerancePoints => 6;

        public bool AddFightValueOnFirstLevel => false;

        public bool AddPainToleranceOnFirstLevel => false;

        public bool AddQualificationPointsOnFirstLevel => true;

        public QualificationList Qualifications => new QualificationList
        {
            new WeaponUsage(),
            new WeaponUsage(),
            new WeaponUsage(),
            new WeaponUsage(),
            new PsiPyarron(),
            new LanguageKnowledge(5),
            new LanguageKnowledge(4),
            new LanguageKnowledge(3),
            new LanguageKnowledge(2),
            new LanguageKnowledge(2),
            new ReadingAndWriting(),
            new LegendKnowledge(QualificationLevel.Master),
            new Etiquette(),
            new Riding(),
            new SexualCulture(),
            new SingingAndMakingMusic(),
            new SoundImitation(),
            new CardSharper()
       };

        public QualificationList FutureQualifications => new QualificationList
        {
            new ValueEstimation(level: 2),
            new Juggling(level: 2),
            new PubFighting(level: 2),
            new FistFighting(level: 3),
            new Knotting(level: 3),
            new Dancing(level: 3),
            new PubFighting(QualificationLevel.Master, 4),
            new WeaponThrowing(QualificationLevel.Master, 4),
            new FreeFromBondage(level: 4),
            new Etiquette(QualificationLevel.Master, 4),
            new CardSharper(QualificationLevel.Master, 5),
            new PsiPyarron(QualificationLevel.Master, 5),
            new Backstab(level: 6),
            new SexualCulture(QualificationLevel.Master, 7),
            new SoundImitation(QualificationLevel.Master, 8)
        };

        public List<PercentQualification> PercentQualifications => new List<PercentQualification>
        {
            new Climbing(25),
            new Falling(5),
            new Jumping(10),
            new LockPicking(25),
            new Sneaking(20),
            new Stealth(10),
            new Tightrope(5),
            new PickPocketing(5),
            new TrapDetect(10),
            new SecretDoorSearching(5),
        };

        public SpecialQualificationList SpecialQualifications => new SpecialQualificationList
        {
            new BardDetectMagicalObjects(),
            new BardMagic()
        };

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(3)]
		public byte GetPainToleranceModifier() => (byte)(DiceThrow._1K6() + 3);

        public override string ToString() => Lng.Elem("Bard");
    }
}
