using MagusCharacterGenerator.GameSystem;
using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Shields
{
    class LittleShield : Shield
    {
        public double AttacksPerRound => 1;

        public byte InitiatingValue => 1;

        public byte DefendingValue => 20;

        public byte MovementObstructiveFactor => 0;

        public double Weight => 1;

        public Money Price => new Money(0, 6);

		[DiceThrow(ThrowType._1K6)]
		public byte GetDamage() => (byte)DiceThrow._1K6();

        public override string ToString() => Lng.Elem("Little shield");
    }
}