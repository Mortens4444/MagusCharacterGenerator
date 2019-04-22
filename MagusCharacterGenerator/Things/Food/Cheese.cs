using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Food
{
	class Cheese
	{
		public string Name => "Cheese";

		public Money Price => new Money(0, 0, 2);

		public override string ToString() => Lng.Elem("Cheese");
	}
}
