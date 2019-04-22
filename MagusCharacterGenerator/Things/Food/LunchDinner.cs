using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Food
{
	class LunchDinner
	{
		public string Name => "Lunch, dinner";

		public Money Price => new Money(0, 0, 5);

		public override string ToString() => Lng.Elem("Lunch, dinner");
	}
}
