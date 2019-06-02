using MagusCharacterGenerator.GameSystem;
using MagusCharacterGenerator.Qualifications;
using System.Collections.Generic;

namespace MagusCharacterGenerator.Races
{
	abstract class Race : IRace
	{
		protected readonly DiceThrow DiceThrow = new DiceThrow();

		public virtual QualificationList Qualifications => new QualificationList();

		public virtual List<PercentQualification> PercentQualifications => new List<PercentQualification>();

		public virtual SpecialQualificationList SpecialQualifications => new SpecialQualificationList();

		public virtual short Strength => 0;

		public virtual short Speed => 0;

		public virtual short Dexterity => 0;

		public virtual short Stamina => 0;

		public virtual short Health => 0;

		public virtual short Beauty => 0;

		public virtual short Intelligence => 0;

		public virtual short WillPower => 0;

		public virtual short Astral => 0;
	}
}
