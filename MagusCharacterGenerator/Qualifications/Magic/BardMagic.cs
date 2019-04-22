using MagusCharacterGenerator.GameSystem.Magic;
using Mtf.Languages;

namespace MagusCharacterGenerator.Qualifications.Magic
{
    class BardMagic : Sorcery
    {
        //ManaPoints = IQ 10 feletti része.

        public override string ToString() => Lng.Elem("Bard magic");
    }
}
