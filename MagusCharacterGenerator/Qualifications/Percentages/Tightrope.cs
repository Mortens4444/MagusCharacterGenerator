using Mtf.Languages;

namespace MagusCharacterGenerator.Qualifications.Percentages
{
    class Tightrope : PercentQualification
    {
        public Tightrope(byte percent)
            : base(percent)
        {
        }

        public override string ToString() => Lng.Elem("Tightrope");
    }
}
