using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Animals
{
	class HorsePony
	{
		public string Name => "Horse, pony";

		public Money Price => new Money(0, 8, 0);

		public override string ToString() => Lng.Elem("Horse, pony");
	}
}
