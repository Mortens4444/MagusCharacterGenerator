using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Food
{
	class HoneyBark
	{
		public string Name => "Honey, bark";

		public Money Price => new Money(0, 0, 4);

		public override string ToString() => Lng.Elem("Honey, bark");
	}
}
