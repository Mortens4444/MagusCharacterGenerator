using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Animals
{
	class HorseTraveler
	{
		public string Name => "Horse, traveler";

		public Money Price => new Money(1, 0, 0);

		public override string ToString() => Lng.Elem("Horse, traveler");
	}
}
