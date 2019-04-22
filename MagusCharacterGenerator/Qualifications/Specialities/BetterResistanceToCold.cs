using MagusCharacterGenerator.GameSystem.Qualifications;

namespace MagusCharacterGenerator.Qualifications.Specialities
{
	class BetterResistanceToCold : ISpecialQualification
	{
		public sbyte ResistanceModifier { get; }

		public BetterResistanceToCold(sbyte resistanceModifier)
		{
			ResistanceModifier = resistanceModifier;
		}
	}
}
