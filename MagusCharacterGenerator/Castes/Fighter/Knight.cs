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
		public short Strength => DiceThrow._1K6_Plus_12_Plus_SpecialTraining();

		[DiceThrow(ThrowType._3K6_2_Times)]
		public short Speed => DiceThrow._3K6_2_Times();

		[DiceThrow(ThrowType._3K6_2_Times)]
		public short Dexterity => DiceThrow._3K6_2_Times();

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(8)]
		[SpecialTraining]
		public short Stamina => DiceThrow._1K10_Plus_8_Plus_SpecialTraining();

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(10)]
		public short Health => DiceThrow._1K10_Plus_10();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		[SpecialTraining]
		public short Beauty => DiceThrow._2K6_Plus_6_Plus_SpecialTraining();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public short Intelligence => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(8)]
		public short WillPower => DiceThrow._1K10_Plus_8();

		[DiceThrow(ThrowType._3K6_2_Times)]
		public short Astral => DiceThrow._3K6_2_Times();

		[DiceThrow(ThrowType._2K6)]
		public short Gold => DiceThrow._2K6();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(8)]
		public byte Bravery => (byte)(DiceThrow._2K6() + 8);

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(8)]
		public byte Erudition => (byte)(DiceThrow._2K6() + 8);

		public byte InitiatingBaseValue => 5;

        public byte AttackingBaseValue => 20;

        public byte DefendingBaseValue => 75;

        public byte AimingBaseValue => throw new InvalidOperationException();

        public byte FightValueModifier => 12;

        public byte BaseQualificationPoints => 4;

        public byte QualificationPointsModifier => 7;

        public byte PercentQualificationModifier => 0;

        public byte BaseLifePoints => 7;

        public byte BasePainTolerancePoints => 6;

        public bool AddFightValueOnFirstLevel => false;

        public bool AddPainToleranceOnFirstLevel => true;

        public bool AddQualificationPointsOnFirstLevel => true;

        public QualificationList Qualifications => new QualificationList
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

        public QualificationList FutureQualifications => new QualificationList
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

        public List<PercentQualification> PercentQualifications => new List<PercentQualification>
        {
        };

        public SpecialQualificationList SpecialQualifications => new SpecialQualificationList
        {
        };

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(5)]
		public byte GetPainToleranceModifier() => (byte)(DiceThrow._1K6() + 5);

        public override string ToString() => Lng.Elem("Knight");
    }
}
