using MagusCharacterGenerator.GameSystem;
using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.FightMode;
using MagusCharacterGenerator.GameSystem.Qualifications;
using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Battle;
using MagusCharacterGenerator.Qualifications.Laical;
using MagusCharacterGenerator.Qualifications.Percentages;
using MagusCharacterGenerator.Qualifications.Scientific.Psi;
using MagusCharacterGenerator.Qualifications.Specialities;
using Mtf.Languages;
using System.Collections.Generic;

namespace MagusCharacterGenerator.Castes.Slan
{
    class SwordMaster : Caste, ICaste, IJustFight
	{
		public SwordMaster(byte level = 1) : base(level) { }

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(8)]
		public short Strength => DiceThrow._1K10_Plus_8();

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(12)]
		[SpecialTraining]
		public short Speed => DiceThrow._1K6_Plus_12_Plus_SpecialTraining();

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(14)]
		public short Dexterity => DiceThrow._1K6_Plus_14();

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(8)]
		public short Stamina => DiceThrow._1K10_Plus_8();

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(8)]
		public short Health => DiceThrow._1K10_Plus_8();

		[DiceThrow(ThrowType._3K6_2_Times)]
		public short Beauty => DiceThrow._3K6_2_Times();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public short Intelligence => DiceThrow._2K6_Plus_6();

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(12)]
		public short WillPower => DiceThrow._1K6_Plus_12();

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(8)]
		public short Astral => DiceThrow._1K10_Plus_8();

		[DiceThrow(ThrowType._1K6)]
		public short Gold => DiceThrow._1K6();

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(8)]
		public byte Bravery => (byte)(DiceThrow._2K6() + 8);

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(8)]
		public byte Erudition => (byte)(DiceThrow._2K6() + 8);

		public byte InitiatingBaseValue => 10;

        public byte AttackingBaseValue => 20;

        public byte DefendingBaseValue => 75;

        public byte AimingBaseValue => 0;

        public byte FightValueModifier => 8;

        public byte BaseQualificationPoints => 4;

        public byte QualificationPointsModifier => 5;

        public byte PercentQualificationModifier => 18;

        public byte BaseLifePoints => 4;

        public byte BasePainTolerancePoints => 8;

        public bool AddFightValueOnFirstLevel => true;

        public bool AddPainToleranceOnFirstLevel => false;

        public bool AddQualificationPointsOnFirstLevel => true;

        public QualificationList Qualifications => new QualificationList
        {
            new PsiSlanWay(),
            new WeaponUsage(),
            new WeaponUsage(),
            new WeaponUsage(),
            new WeaponBreaking(),
            new FistFighting(),
            new Wrestling(),
            new BlindFighting(),
            new Leadership(),
            new Etiquette(),
            new Riding(),
            new Swimming(),
            new Running()
       };

        public QualificationList FutureQualifications => new QualificationList
        {
            new Riding(QualificationLevel.Master, 3),
            new WeaponBreaking(QualificationLevel.Master, 4),
            new BlindFighting(QualificationLevel.Master, 5),
            new WeaponUsage(QualificationLevel.Master, 5)
        };

        public List<PercentQualification> PercentQualifications => new List<PercentQualification>
        {
            new Climbing(10),
            new Falling(20),
            new Jumping(10)
        };

        public SpecialQualificationList SpecialQualifications => new SpecialQualificationList
        {
            new SlanDodgeFromRangedAttacks(),
            new SwordFighterMagicSword()
        };

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(5)]
		public byte GetPainToleranceModifier() => (byte)(DiceThrow._1K6() + 5);

        public override string ToString()
        {
            return Lng.Elem("Sword master");
        }
    }
}
