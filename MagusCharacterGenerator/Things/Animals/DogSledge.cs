using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Animals
{
	class DogSledge
	{
		public string Name => "Dog, sledge";

		public Money Price => new Money(0, 0, 120);

		public override string ToString() => Lng.Elem("Dog, sledge");
	}
}
