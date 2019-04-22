using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Travelling
{
	class CartWheel
	{
		public string Name => "Cart wheel";

		public Money Price => new Money(0, 0, 40);

		public override string ToString() => Lng.Elem("Cart wheel");
	}
}
