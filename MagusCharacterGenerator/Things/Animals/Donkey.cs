using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Animals
{
	class Donkey
	{
		public string Name => "Donkey";

		public Money Price => new Money(0, 7, 0);

		public override string ToString() => Lng.Elem("Donkey");
	}
}
