using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Animals
{
	class DogHousekeeper
	{
		public string Name => "Dog, housekeeper";

		public Money Price => new Money(0, 0, 80);

		public override string ToString() => Lng.Elem("Dog, housekeeper");
	}
}
