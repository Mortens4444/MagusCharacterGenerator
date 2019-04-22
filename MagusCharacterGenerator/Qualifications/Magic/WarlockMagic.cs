using MagusCharacterGenerator.GameSystem.Magic;
using Mtf.Languages;

namespace MagusCharacterGenerator.Qualifications.Magic
{
    class WarlockMagic : Sorcery
    {
        public WarlockMagic()
        {
            ManaPoints = 7;
        }

        public override string ToString() => Lng.Elem("Warlock magic");
    }
}
