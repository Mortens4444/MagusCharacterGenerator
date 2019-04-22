using MagusCharacterGenerator.GameSystem.Qualifications;

namespace MagusCharacterGenerator.Qualifications.Specialities
{
	class BetterResistanceToFire : ISpecialQualification
	{
		public sbyte ResistanceModifier { get; }

		public BetterResistanceToFire(sbyte resistanceModifier)
		{
			ResistanceModifier = resistanceModifier;
		}
	}
}
