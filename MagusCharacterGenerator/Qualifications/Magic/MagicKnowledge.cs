using MagusCharacterGenerator.GameSystem.Magic;
using Mtf.Languages;

namespace MagusCharacterGenerator.Qualifications.Magic
{
    class MagicKnowledge : Sorcery
    {
        public MagicKnowledge()
        {
            ManaPoints = 10;
        }

        public override ushort GetManaPointsModifier()
        {
            return 0;
        }

        public override string ToString() => Lng.Elem("Magic knowledge");
    }
}
