using Mtf.Languages;

namespace MagusCharacterGenerator.Qualifications.Percentages
{
    class PickPocketing : PercentQualification
    {
        public PickPocketing(byte percent)
            : base(percent)
        {
        }

        public override string ToString() => Lng.Elem("Pick pocketing");
    }
}
