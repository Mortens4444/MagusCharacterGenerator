using MagusCharacterGenerator.GameSystem;
using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Shields
{
    class LargeShield : Shield
    {
        public double AttacksPerRound => 1/2;

        public byte InitiatingValue => 0;

        public byte DefendingValue => 50;

        public byte MovementObstructiveFactor => 5;

        public double Weight => 6;

        public Money Price => new Money(6);

		[DiceThrow(ThrowType._1K6)]
		public byte GetDamage() => (byte)DiceThrow._1K6();

        public override string ToString() => Lng.Elem("Large shield");
    }
}