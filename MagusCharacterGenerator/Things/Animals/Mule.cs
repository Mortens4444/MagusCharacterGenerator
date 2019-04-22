using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Animals
{
	class Mule
	{
		public string Name => "Mule";

		public Money Price => new Money(0, 8, 0);

		public override string ToString() => Lng.Elem("Mule");
	}
}
