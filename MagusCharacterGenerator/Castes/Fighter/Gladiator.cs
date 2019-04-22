using MagusCharacterGenerator.GameSystem;
using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.FightMode;
using MagusCharacterGenerator.GameSystem.Qualifications;
using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Battle;
using MagusCharacterGenerator.Qualifications.Percentages;
using MagusCharacterGenerator.Qualifications.Specialities;
using Mtf.Languages;
using System.Collections.Generic;

namespace MagusCharacterGenerator.Castes.Fighter
{
    class Gladiator : Caste, ICaste, IJustFight
    {
		public Gladiator(byte level = 1) : base(level) { }

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(12)]
		[SpecialTraining]
		public short Strength => DiceThrow._1K6_Plus_12_Plus_SpecialTraining();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		[SpecialTraining]
		public short Speed => DiceThrow._2K6_Plus_6_Plus_SpecialTraining();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		[SpecialTraining]
		public short Dexterity => DiceThrow._2K6_Plus_6_Plus_SpecialTraining();

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(12)]
		[SpecialTraining]
		public short Stamina => DiceThrow._1K6_Plus_12_Plus_SpecialTraining();

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(10)]
		public short Health => DiceThrow._1K10_Plus_10();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public short Beauty => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._3K6)]
		public short Intelligence => DiceThrow._3K6();

		[DiceThrow(ThrowType._3K6)]
		public short WillPower => DiceThrow._3K6();

		[DiceThrow(ThrowType._3K6)]
		public short Astral => DiceThrow._3K6();

		[DiceThrow(ThrowType._2K6)]
		public short Gold => DiceThrow._2K6();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(8)]
		public byte Bravery => (byte)(DiceThrow._2K6() + 8);

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(8)]
		public byte Erudition => (byte)(DiceThrow._2K6() + 8);

		public byte InitiatingBaseValue => 9;

        public byte AttackingBaseValue => 20;

        public byte DefendingBaseValue => 75;

        public byte AimingBaseValue => 0;

        public byte FightValueModifier => 12;

        public byte BaseQualificationPoints => 3;

        public byte QualificationPointsModifier => 6;

        public byte PercentQualificationModifier => 0;

        public byte BaseLifePoints => 8;

        public byte BasePainTolerancePoints => 7;

        public bool AddFightValueOnFirstLevel => false;

        public bool AddPainToleranceOnFirstLevel => true;

        public bool AddQualificationPointsOnFirstLevel => true;

        public QualificationList Qualifications => new QualificationList
        {
            new WeaponUsage(),
            new WeaponUsage(),
            new WeaponUsage(),
            new WeaponUsage(),
            new Wrestling(),
            new FistFighting(),
            new TwoHandedCombat(),
            new HeavyArmorWearing(),
            new ShieldUsing(),
            new WeaponBreaking()
        };

        public QualificationList FutureQualifications => new QualificationList
        {
            new WeaponUsage(level: 2),
            new WeaponUsage(level: 4),
            new WeaponUsage(QualificationLevel.Master),
            new TwoHandedCombat(QualificationLevel.Master),
            new BlindFighting(level: 6),
            new WeaponUsage(level: 7),
            new WeaponUsage(level: 7),
            new ShieldUsing(QualificationLevel.Master),
            new WeaponBreaking(QualificationLevel.Master)
        };

        public List<PercentQualification> PercentQualifications => new List<PercentQualification>
        {
            new Falling(30),
            new Jumping(20)
        };

        public SpecialQualificationList SpecialQualifications => new SpecialQualificationList
        {
            new GladiatorFightAgainstOneEnemy(),
            new GladiatorFightInFrontOfAudience()
        };

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(5)]
		public byte GetPainToleranceModifier() => (byte)(DiceThrow._1K6() + 5);

        public override string ToString() => Lng.Elem("Gladiator");
    }
}
