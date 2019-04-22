using Mtf.Languages;

namespace MagusCharacterGenerator.Qualifications.Percentages
{
    class Stealth : PercentQualification
    {
        public Stealth(byte percent)
            : base(percent)
        {
        }

        public override string ToString() => Lng.Elem("Stealth");
    }
}
