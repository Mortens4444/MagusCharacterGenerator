using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Animals
{
	class Cat
	{
		public string Name => "Cat";

		public Money Price => new Money(0, 0, 5);

		public override string ToString() => Lng.Elem("Cat");
	}
}
