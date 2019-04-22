using MagusCharacterGenerator.GameSystem.Qualifications;
using Mtf.Languages;

namespace MagusCharacterGenerator.Qualifications.Specialities
{
    class BetterHearing : ISpecialQualification
    {
        public double Multiplier { get; }

        public BetterHearing(double multiplier)
        {
            Multiplier = multiplier;
        }

        public override string ToString() => Lng.Elem("Better hearing");
    }
}
