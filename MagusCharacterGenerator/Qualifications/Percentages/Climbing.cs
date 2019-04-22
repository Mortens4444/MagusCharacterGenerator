using Mtf.Languages;

namespace MagusCharacterGenerator.Qualifications.Percentages
{
    class Climbing : PercentQualification
    {
        public Climbing(byte percent)
            : base(percent)
        {
        }

        public override string ToString() => Lng.Elem("Climbing");
    }
}
