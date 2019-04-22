using MagusCharacterGenerator.GameSystem.Qualifications;

namespace MagusCharacterGenerator.Qualifications.Specialities
{
    class NotTolerateStrongLight : ISpecialQualification
    {
		public byte MaximumToleratedLightEnergy { get; }

		public sbyte ModifierInStrongLight { get; }

        public NotTolerateStrongLight(byte maximumToleratedLightEnergy, sbyte modifierInStrongLight)
        {
			MaximumToleratedLightEnergy = maximumToleratedLightEnergy;
			ModifierInStrongLight = modifierInStrongLight;
		}
    }
}
