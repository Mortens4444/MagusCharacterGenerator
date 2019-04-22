using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Food
{
	class SpecialSpice
	{
		public string Name => "Special spice";

		public Money Price => new Money(0, 0, 20);

		public override string ToString() => Lng.Elem("Special spice");
	}
}
