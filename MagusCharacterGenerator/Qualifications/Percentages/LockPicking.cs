using Mtf.Languages;

namespace MagusCharacterGenerator.Qualifications.Percentages
{
    class LockPicking : PercentQualification
    {
        public LockPicking(byte percent)
            : base(percent)
        {
        }

        public override string ToString() => Lng.Elem("Lock picking");
    }
}
