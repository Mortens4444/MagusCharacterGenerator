using MagusCharacterGenerator.GameSystem;
using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Shields
{
    class MediumShield : Shield
    {
        public double AttacksPerRound => 1;

        public byte InitiatingValue => 0;

        public byte DefendingValue => 35;

        public byte MovementObstructiveFactor => 1;

        public double Weight => 3;

        public Money Price => new Money(1, 6);

		[DiceThrow(ThrowType._1K6)]
		public byte GetDamage() => (byte)DiceThrow._1K6();

        public override string ToString() => Lng.Elem("Medium shield");
    }
}