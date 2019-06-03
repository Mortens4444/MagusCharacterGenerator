using MagusCharacterGenerator.GameSystem;
using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.FightMode;
using MagusCharacterGenerator.GameSystem.Qualifications;
using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Battle;
using MagusCharacterGenerator.Qualifications.Laical;
using MagusCharacterGenerator.Qualifications.Scientific;
using MagusCharacterGenerator.Qualifications.Scientific.Psi;
using Mtf.Languages;
using System;
using System.Collections.Generic;

namespace MagusCharacterGenerator.Castes.Fighter
{
    class Knight : Caste, ICaste, IHateRangedWeapons
	{
		public Knight(byte level = 1) : base(level) { }

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(12)]
		[SpecialTraining]
		public override short Strength => DiceThrow._1K6_Plus_12_Plus_SpecialTraining();

		[DiceThrow(ThrowType._3K6_2_Times)]
		public override short Speed => DiceThrow._3K6_2_Times();

		[DiceThrow(ThrowType._3K6_2_Times)]
		public override short Dexterity => DiceThrow._3K6_2_Times();

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(8)]
		[SpecialTraining]
		public override short Stamina => DiceThrow._1K10_Plus_8_Plus_SpecialTraining();

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(10)]
		public override short Health => DiceThrow._1K10_Plus_10();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		[SpecialTraining]
		public override short Beauty => DiceThrow._2K6_Plus_6_Plus_SpecialTraining();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public override short Intelligence => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(8)]
		public override short WillPower => DiceThrow._1K10_Plus_8();

		[DiceThrow(ThrowType._3K6_2_Times)]
		public override short Astral => DiceThrow._3K6_2_Times();

		[DiceThrow(ThrowType._2K6)]
		public override short Gold => DiceThrow._2K6();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(8)]
		public override byte Bravery => (byte)(DiceThrow._2K6() + 8);

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(8)]
		public override byte Erudition => (byte)(DiceThrow._2K6() + 8);

		public override byte InitiatingBaseValue => 5;

        public override byte AttackingBaseValue => 20;

        public override byte DefendingBaseValue => 75;

        public override byte AimingBaseValue => throw new InvalidOperationException();

        public override byte FightValueModifier => 12;

        public override byte BaseQualificationPoints => 4;

        public override byte QualificationPointsModifier => 7;

        public override byte PercentQualificationModifier => 0;

        public override byte BaseLifePoints => 7;

        public override byte BasePainTolerancePoints => 6;

        public override bool AddFightValueOnFirstLevel => false;

        public override bool AddPainToleranceOnFirstLevel => true;

        public override bool AddQualificationPointsOnFirstLevel => true;

        public override QualificationList Qualifications => new QualificationList
        {
            new HeavyArmorWearing(),
            new ShieldUsing(),
            new WeaponUsage(),
            new WeaponUsage(),
            new WeaponUsage(),
            new WeaponUsage(),
            new WeaponUsage(),
            new WeaponKnowledge(),
            new Leadership(),
            new Etiquette(),
            new Riding(QualificationLevel.Master),
            new LanguageKnowledge(4),
            new LanguageKnowledge(2),
            new LanguageKnowledge(2),
            new LanguageKnowledge(2),
            new ReadingAndWriting(),
            new Heraldry()
        };

        public override QualificationList FutureQualifications => new QualificationList
        {
            new Heraldry(QualificationLevel.Master, 3),
            new ShieldUsing(QualificationLevel.Master, 4),
            new PsiPyarron(level: 4),
            new WoundHealing(level: 4),
            new WeaponUsage(QualificationLevel.Master, 5),
            new HeavyArmorWearing(QualificationLevel.Master, 8),
            new Leadership(QualificationLevel.Master, 9),
            new PsiPyarron(QualificationLevel.Master, 12)
        };

        public override List<PercentQualification> PercentQualifications => new List<PercentQualification>
        {
        };

        public override SpecialQualificationList SpecialQualifications => new SpecialQualificationList
        {
        };

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(5)]
		public override byte GetPainToleranceModifier() => (byte)(DiceThrow._1K6() + 5);

        public override string ToString() => Lng.Elem("Knight");
    }
}
