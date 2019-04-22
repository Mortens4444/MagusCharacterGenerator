using Mtf.Languages;

namespace MagusCharacterGenerator.Qualifications.Percentages
{
    class TrapDetect : PercentQualification
    {
        public TrapDetect(byte percent)
            : base(percent)
        {
        }

        public override string ToString() => Lng.Elem("Trap detect");
    }
}
