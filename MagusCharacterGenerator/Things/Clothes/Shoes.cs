using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Clothes
{
	class Shoes
	{
		public string Name => "Shoes";

		public Money Price => new Money(0, 1, 0);

		public override string ToString() => Lng.Elem("Shoes");
	}
}
