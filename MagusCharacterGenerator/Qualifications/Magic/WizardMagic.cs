using MagusCharacterGenerator.GameSystem.Magic;
using Mtf.Languages;

namespace MagusCharacterGenerator.Qualifications.Magic
{
    class WizardMagic : Sorcery
    {
        public WizardMagic()
        {
            ManaPoints = 10;
        }

        public override string ToString() => Lng.Elem("Wizard magic");
    }
}
