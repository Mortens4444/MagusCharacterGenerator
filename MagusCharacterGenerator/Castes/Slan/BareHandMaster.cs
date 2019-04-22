using MagusCharacterGenerator.GameSystem;
using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.FightMode;
using MagusCharacterGenerator.GameSystem.Qualifications;
using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Battle;
using MagusCharacterGenerator.Qualifications.Laical;
using MagusCharacterGenerator.Qualifications.Percentages;
using MagusCharacterGenerator.Qualifications.Scientific;
using MagusCharacterGenerator.Qualifications.Scientific.Psi;
using MagusCharacterGenerator.Qualifications.Specialities;
using Mtf.Languages;
using System.Collections.Generic;

namespace MagusCharacterGenerator.Castes.Slan
{
    class BareHandMaster : Caste, ICaste, IJustFight
	{
		public BareHandMaster(byte level = 1) : base(level) { }

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(8)]
		public short Strength => DiceThrow._1K10_Plus_8();

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(14)]
		public short Speed => DiceThrow._1K6_Plus_14();

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(12)]
		public short Dexterity => DiceThrow._1K6_Plus_12();

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(12)]
		public short Stamina => DiceThrow._1K6_Plus_12();

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(10)]
		public short Health => DiceThrow._1K10_Plus_10();

		[DiceThrow(ThrowType._3K6_2_Times)]
		public short Beauty => DiceThrow._3K6_2_Times();

		[DiceThrow(ThrowType._3K6_2_Times)]
		public short Intelligence => DiceThrow._3K6_2_Times();

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(12)]
		public short WillPower => DiceThrow._1K6_Plus_12();

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(8)]
		public short Astral => DiceThrow._1K10_Plus_8();

		[DiceThrow(ThrowType._1K3)]
		public short Gold => DiceThrow._1K3();

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

        public byte PercentQualificationModifier => 22;

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
            new WeaponUsage(),
            new WeaponUsage(),
            new WeaponUsage(),
            new WeaponUsage(),
            new WeaponUsage(),
            new WeaponUsage(),
            new WeaponUsage(),
            new WeaponThrowing(),
            new WeaponThrowing(),
            new WeaponThrowing(),
            new WeaponThrowing(),
            new WeaponBreaking(),
            new Riding(),
            new Swimming(),
            new Running(),
            new BlindFighting()
       };

        public QualificationList FutureQualifications => new QualificationList
        {
            new WoundHealing(level: 2),
            new WeaponBreaking(QualificationLevel.Master, 4),
            new BlindFighting(QualificationLevel.Master, 5),
            new WoundHealing(QualificationLevel.Master, 6)
        };

        public List<PercentQualification> PercentQualifications => new List<PercentQualification>
        {
            new Climbing(20),
            new Falling(35),
            new Jumping(30)
        };

        public SpecialQualificationList SpecialQualifications => new SpecialQualificationList
        {
            new SlanDodgeFromRangedAttacks(),
            new BareHandFighterRunning(),
            new BareHandFighterMagicHand()
        };

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(5)]
		public byte GetPainToleranceModifier() => (byte)(DiceThrow._1K6() + 5);

        public override string ToString() => Lng.Elem("Bare-hand master");
    }
}
