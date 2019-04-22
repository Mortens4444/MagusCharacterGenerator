using Mtf.Languages;

namespace MagusCharacterGenerator.Qualifications.Percentages
{
    class Falling : PercentQualification
    {
        public Falling(byte percent)
            : base(percent)
        {
        }

        public override string ToString() => Lng.Elem("Falling");
    }
}
