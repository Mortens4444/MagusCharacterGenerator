using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Food
{
	class WildMeatOneDose
	{
		public string Name => "Wild meat, one dose";

		public Money Price => new Money(0, 0, 4);

		public override string ToString() => Lng.Elem("Wild meat, one dose");
	}
}
