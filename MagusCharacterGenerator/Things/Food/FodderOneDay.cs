using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Food
{
	class FodderOneDay
	{
		public string Name => "Fodder, one day";

		public Money Price => new Money(0, 0, 4);

		public override string ToString() => Lng.Elem("Fodder, one day");
	}
}
