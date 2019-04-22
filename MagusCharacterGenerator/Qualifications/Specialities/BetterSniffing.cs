using MagusCharacterGenerator.GameSystem.Qualifications;
using Mtf.Languages;

namespace MagusCharacterGenerator.Qualifications.Specialities
{
    class BetterSniffing : ISpecialQualification
    {
        public double Multiplier { get; }

        public BetterSniffing(double multiplier)
        {
            Multiplier = multiplier;
        }

        public override string ToString() => Lng.Elem("Better sniffing");
    }
}
