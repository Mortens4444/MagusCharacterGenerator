using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Clothes
{
	class Stockings
	{
		public string Name => "Stockings";

		public Money Price => new Money(0, 0, 6);

		public override string ToString() => Lng.Elem("Stockings");
	}
}
