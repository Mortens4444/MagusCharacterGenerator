using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class Basket
	{
		public string Name => "Basket";

		public Money Price => new Money(0, 0, 6);

		public override string ToString() => Lng.Elem("Basket");
	}
}
