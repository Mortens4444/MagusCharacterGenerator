using MagusCharacterGenerator.GameSystem.Qualifications;

namespace MagusCharacterGenerator.Qualifications.Specialities
{
    class ResistanceToNecromantia : ISpecialQualification
    {
        public sbyte ResistanceToMagicModifier { get; }

        public ResistanceToNecromantia(sbyte resistanceToMagicModifier)
        {
            ResistanceToMagicModifier = resistanceToMagicModifier;
        }
    }
}
