using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class Candle
	{
		public string Name => "Candle";

		public Money Price => new Money(0, 0, 2);

		public override string ToString() => Lng.Elem("Candle");
	}
}
