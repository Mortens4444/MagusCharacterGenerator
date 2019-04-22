using MagusCharacterGenerator.GameSystem.Qualifications;

namespace MagusCharacterGenerator.Qualifications.Specialities
{
    class ResistanceToWaterMagic : ISpecialQualification
    {
        public sbyte ResistanceToMagicModifier { get; }

        public ResistanceToWaterMagic(sbyte resistanceToMagicModifier)
        {
            ResistanceToMagicModifier = resistanceToMagicModifier;
        }
    }
}
