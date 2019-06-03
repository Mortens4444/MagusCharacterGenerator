using System.Collections.Generic;
using MagusCharacterGenerator.GameSystem;
using MagusCharacterGenerator.Qualifications;

namespace MagusCharacterGenerator.Castes
{
	abstract class Caste : ICaste
    {
		protected const string _1K6_Plus_12_Plus_SpecialTraining = "1K6 + 12 + Special training";

		protected readonly DiceThrow DiceThrow = new DiceThrow();

        public string Name { get; set; }

        public byte Level { get; set; }

		public abstract short Gold { get; }

		public abstract byte Bravery { get; }

		public abstract byte Erudition { get; }

		public abstract byte InitiatingBaseValue { get; }

		public abstract byte AttackingBaseValue { get; }

		public abstract byte DefendingBaseValue { get; }

		public abstract byte AimingBaseValue { get; }

		public abstract byte FightValueModifier { get; }

		public abstract byte BaseQualificationPoints { get; }

		public abstract byte QualificationPointsModifier { get; }

		public abstract byte PercentQualificationModifier { get; }

		public abstract byte BaseLifePoints { get; }

		public abstract byte BasePainTolerancePoints { get; }

		public abstract bool AddFightValueOnFirstLevel { get; }

		public abstract bool AddPainToleranceOnFirstLevel { get; }

		public abstract bool AddQualificationPointsOnFirstLevel { get; }

		public abstract QualificationList Qualifications { get; }

		public abstract QualificationList FutureQualifications { get; }

		public abstract List<PercentQualification> PercentQualifications { get; }

		public abstract SpecialQualificationList SpecialQualifications { get; }

		public abstract short Strength { get; }

		public abstract short Speed { get; }

		public abstract short Dexterity { get; }

		public abstract short Stamina { get; }

		public abstract short Health { get; }

		public abstract short Beauty { get; }

		public abstract short Intelligence { get; }

		public abstract short WillPower { get; }

		public abstract short Astral { get; }

		public Caste(byte level)
		{
			Level = level;
		}

		public abstract byte GetPainToleranceModifier();
	}
}
