using MagusCharacterGenerator.GameSystem.Qualifications;
using Mtf.Languages;

namespace MagusCharacterGenerator.Qualifications.Specialities
{
    class BetterSeeing : ISpecialQualification
    {
        public double Multiplier { get; }

        public BetterSeeing(double multiplier)
        {
            Multiplier = multiplier;
        }

        public override string ToString() => Lng.Elem("Better seeing");
    }
}
