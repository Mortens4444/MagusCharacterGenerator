using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Animals
{
	class Goats
	{
		public string Name => "Goats";

		public Money Price => new Money(0, 3, 0);

		public override string ToString() => Lng.Elem("Goats");
	}
}
