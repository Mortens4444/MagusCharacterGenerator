using MagusCharacterGenerator.GameSystem.Qualifications;
using Mtf.Languages;

namespace MagusCharacterGenerator.Qualifications.Specialities
{
    class AdditionalLifePoints : ISpecialQualification
    {
        public byte ExtraLifePoints { get; }

        public AdditionalLifePoints(byte extraLifePoints)
        {
			ExtraLifePoints = extraLifePoints;
        }
    }
}
