using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Animals
{
	class Sheep
	{
		public string Name => "Sheep";

		public Money Price => new Money(0, 4, 0);

		public override string ToString() => Lng.Elem("Sheep");
	}
}
