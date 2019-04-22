using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Food
{
	class BeerMug
	{
		public string Name => "Beer, mug";

		public Money Price => new Money(0, 0, 1);

		public override string ToString() => Lng.Elem("Beer, mug");
	}
}
