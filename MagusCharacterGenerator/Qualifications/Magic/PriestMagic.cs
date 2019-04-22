using MagusCharacterGenerator.GameSystem;
using MagusCharacterGenerator.GameSystem.Magic;
using Mtf.Languages;

namespace MagusCharacterGenerator.Qualifications.Magic
{
    class PriestMagic : Sorcery
    {
        private readonly DiceThrow diceThrow = new DiceThrow();

        public PriestMagic()
        {
            ManaPoints = 9;
        }

        public override ushort GetManaPointsModifier()
        {
            return (ushort)(diceThrow._1K3() + 6);
        }

        public override string ToString() => Lng.Elem("Priest magic");
    }
}
