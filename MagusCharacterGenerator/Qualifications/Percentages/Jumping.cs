using Mtf.Languages;

namespace MagusCharacterGenerator.Qualifications.Percentages
{
    class Jumping : PercentQualification
    {
        public Jumping(byte percent)
            : base(percent)
        {
        }

        public override string ToString() => Lng.Elem("Jumping");
    }
}
