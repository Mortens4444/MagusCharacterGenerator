using MagusCharacterGenerator.GameSystem.Magic;
using Mtf.Languages;

namespace MagusCharacterGenerator.Qualifications.Magic
{
    class WitchMagic : Sorcery
    {
        public WitchMagic()
        {
            ManaPoints = 8;
        }

        public override string ToString() => Lng.Elem("Witch magic");
    }
}
