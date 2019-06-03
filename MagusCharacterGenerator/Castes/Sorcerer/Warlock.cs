using MagusCharacterGenerator.GameSystem;
using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.FightMode;
using MagusCharacterGenerator.GameSystem.Qualifications;
using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Battle;
using MagusCharacterGenerator.Qualifications.Magic;
using MagusCharacterGenerator.Qualifications.Percentages;
using MagusCharacterGenerator.Qualifications.Scientific;
using MagusCharacterGenerator.Qualifications.Scientific.Psi;
using MagusCharacterGenerator.Qualifications.Underworld;
using Mtf.Languages;
using System.Collections.Generic;

namespace MagusCharacterGenerator.Castes.Sorcerer
{
    class Warlord : Caste, ICaste, ILikeMagic
	{
		public Warlord(byte level = 1) : base(level) { }

		[DiceThrow(ThrowType._3K6_2_Times)]
		public override short Strength => DiceThrow._3K6_2_Times();

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(8)]
		public override short Speed => DiceThrow._1K10_Plus_8();

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(12)]
		[SpecialTraining]
		public override short Dexterity => DiceThrow._1K6_Plus_12_Plus_SpecialTraining();

		[DiceThrow(ThrowType._3K6_2_Times)]
		public override short Stamina => DiceThrow._3K6_2_Times();

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

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(12)]
		public override short Astral => DiceThrow._1K6_Plus_12();

		[DiceThrow(ThrowType._2K6)]
		public override short Gold => DiceThrow._2K6();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(8)]
		public override byte Bravery => (byte)(DiceThrow._2K6() + 8);

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(8)]
		public override byte Erudition => (byte)(DiceThrow._2K6() + 8);

		public override byte InitiatingBaseValue => 7;

        public override byte AttackingBaseValue => 17;

        public override byte DefendingBaseValue => 72;

        public override byte AimingBaseValue => 5;

        public override byte FightValueModifier => 7;

        public override byte BaseQualificationPoints => 7;

        public override byte QualificationPointsModifier => 8;

        public override byte PercentQualificationModifier => 15;

        public override byte BaseLifePoints => 3;

        public override byte BasePainTolerancePoints => 4;

        public override bool AddFightValueOnFirstLevel => false;

        public override bool AddPainToleranceOnFirstLevel => false;

        public override bool AddQualificationPointsOnFirstLevel => true;

        public override QualificationList Qualifications => new QualificationList
        {
            new WeaponUsage(),
            new WeaponUsage(),
            new WeaponUsage(),
            new WeaponThrowing(),
            new PsiPyarron(QualificationLevel.Master),
            new LanguageKnowledge(3),
            new LanguageKnowledge(3),
            new LanguageKnowledge(2),
            new ReadingAndWriting(),
            new PoisoningAndNeutralization(),
            new CamouflageOrDisguise(),
            new Herbalism(),
       };

        public override QualificationList FutureQualifications => new QualificationList
        {
            new Backstab(level: 2),
            new PoisoningAndNeutralization(QualificationLevel.Master, 4),
            new Backstab(QualificationLevel.Master, 5),
            new Herbalism(QualificationLevel.Master, 6)
        };

        public override List<PercentQualification> PercentQualifications => new List<PercentQualification>
        {
            new Sneaking(15),
            new Stealth(15)
        };

        public override SpecialQualificationList SpecialQualifications => new SpecialQualificationList
        {
            new WarlockMagic()
        };

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(1)]
		public override byte GetPainToleranceModifier() => (byte)(DiceThrow._1K6() + 1);

        public override string ToString()
        {
            return Lng.Elem("Warlock");
        }
    }
}
