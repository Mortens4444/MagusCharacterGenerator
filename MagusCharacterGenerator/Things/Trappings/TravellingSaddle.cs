using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Trappings
{
	class TravellingSaddle
	{
		public string Name => "Travelling saddle";

		public Money Price => new Money(0, 0, 150);

		public override string ToString() => Lng.Elem("Travelling saddle");
	}
}
