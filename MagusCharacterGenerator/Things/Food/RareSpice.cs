using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Food
{
	class RareSpice
	{
		public string Name => "Rare spice";

		public Money Price => new Money(0, 0, 7);

		public override string ToString() => Lng.Elem("Rare spice");
	}
}
