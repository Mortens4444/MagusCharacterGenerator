using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Food
{
	class MeatOneDose
	{
		public string Name => "Meat, one dose";

		public Money Price => new Money(0, 0, 1);

		public override string ToString() => Lng.Elem("Meat, one dose");
	}
}
