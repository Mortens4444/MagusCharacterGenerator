using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Animals
{
	class DogHunter
	{
		public string Name => "Dog, hunter";

		public Money Price => new Money(0, 2, 0);

		public override string ToString() => Lng.Elem("Dog, hunter");
	}
}
