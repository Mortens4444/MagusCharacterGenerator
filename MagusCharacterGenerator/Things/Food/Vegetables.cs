using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Food
{
	class Vegetables
	{
		public string Name => "Vegetables";

		public Money Price => new Money(0, 0, 1);

		public override string ToString() => Lng.Elem("Vegetables");
	}
}
