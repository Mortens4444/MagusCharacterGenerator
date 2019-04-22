using Mtf.Languages;

namespace MagusCharacterGenerator.Qualifications.Percentages
{
    class Sneaking : PercentQualification
    {
        public Sneaking(byte percent)
            : base(percent)
        {
        }

        public override string ToString() => Lng.Elem("Sneaking");
    }
}
