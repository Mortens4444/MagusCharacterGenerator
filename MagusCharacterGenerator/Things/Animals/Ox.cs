using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Animals
{
	class Ox
	{
		public string Name => "Ox";

		public Money Price => new Money(0, 15, 0);

		public override string ToString() => Lng.Elem("Ox");
	}
}
