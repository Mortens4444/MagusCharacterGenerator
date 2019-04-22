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
using System;
using System.Collections.Generic;

namespace MagusCharacterGenerator.Castes.Believer
{
    abstract class Paladin : Caste, ICaste, IHateRangedWeapons
    {
		public Paladin(byte level) : base(level) { }

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(8)]
		[SpecialTraining]
		public short Strength => DiceThrow._1K10_Plus_8_Plus_SpecialTraining();

		[DiceThrow(ThrowType._3K6_2_Times)]
		public short Speed => DiceThrow._3K6_2_Times();

		[DiceThrow(ThrowType._3K6_2_Times)]
		public short Dexterity => DiceThrow._3K6_2_Times();

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(8)]
		public short Stamina => DiceThrow._1K10_Plus_8();

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(10)]
		public short Health => DiceThrow._1K10_Plus_10();

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(8)]
		public short Beauty => DiceThrow._1K10_Plus_8();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public short Intelligence => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(8)]
		public short WillPower => DiceThrow._1K10_Plus_8();

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(12)]
		public short Astral => DiceThrow._1K6_Plus_12();

		[DiceThrow(ThrowType._1K6)]
		public short Gold => DiceThrow._1K6();

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

        public byte FightValueModifier => 9;

        public byte BaseQualificationPoints => 5;

        public byte QualificationPointsModifier => 5;

        public byte PercentQualificationModifier => 0;

        public byte BaseLifePoints => 8;

        public byte BasePainTolerancePoints => 7;

        public bool AddFightValueOnFirstLevel => false;

        public bool AddPainToleranceOnFirstLevel => false;

        public bool AddQualificationPointsOnFirstLevel => true;

        public virtual QualificationList Qualifications => new QualificationList
        {
            new WeaponUsage(),
            new WeaponUsage(),
            new WeaponUsage(),
            new WeaponUsage(),
            new PsiPyarron(QualificationLevel.Master),
            new LanguageKnowledge(5),
            new LanguageKnowledge(4),
            new HeavyArmorWearing(),
            new ShieldUsing(),
            new Leadership(),
            new ReadingAndWriting(),
            new ReligionKnowledge(),
            new Etiquette(),
            new Heraldry(),
            new Riding(QualificationLevel.Master),
            new SingingAndMakingMusic(),
            new HistoryKnowledge()
       };

        public virtual QualificationList FutureQualifications => new QualificationList();

        public virtual List<PercentQualification> PercentQualifications => new List<PercentQualification>
        {
        };

        public virtual SpecialQualificationList SpecialQualifications => new SpecialQualificationList
        {
            new PriestMagic()
        };

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(5)]
		public byte GetPainToleranceModifier() => (byte)(DiceThrow._1K6() + 5);
    }
}
