using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Travelling
{
	class Cart
	{
		public string Name => "Cart";

		public Money Price => new Money(0, 0, 150);

		public override string ToString() => Lng.Elem("Cart");
	}
}
