using MagusCharacterGenerator.GameSystem.Magic;
using Mtf.Languages;

namespace MagusCharacterGenerator.Qualifications.Magic
{
    class FireWizardMagic : Sorcery
    {
        public FireWizardMagic()
        {
            ManaPoints = 6;
        }

        public override string ToString() => Lng.Elem("Fire wizard magic");
    }
}
