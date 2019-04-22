using MagusCharacterGenerator.GameSystem.Qualifications;

namespace MagusCharacterGenerator.Qualifications.Specialities
{
    class ExtraMagicResistanceOnLevelUp : ISpecialQualification
    {
		public byte ExtraResistancePoints { get; }

		public ExtraMagicResistanceOnLevelUp(byte extraResistancePoints)
		{
			ExtraResistancePoints = extraResistancePoints;
		}
    }
}
