using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Animals
{
	class DogFighting
	{
		public string Name => "Dog, fighting";

		public Money Price => new Money(0, 8, 0);

		public override string ToString() => Lng.Elem("Dog, fighting");
	}
}
