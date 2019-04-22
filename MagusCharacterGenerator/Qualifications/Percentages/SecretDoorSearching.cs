using Mtf.Languages;

namespace MagusCharacterGenerator.Qualifications.Percentages
{
    class SecretDoorSearching : PercentQualification
    {
        public SecretDoorSearching(byte percent)
            : base(percent)
        {
        }

        public override string ToString() => Lng.Elem("Secret door searching");
    }
}
