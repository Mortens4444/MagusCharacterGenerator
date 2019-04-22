using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Animals
{
	class Camel
	{
		public string Name => "Camel";

		public Money Price => new Money(1, 0, 0);

		public override string ToString() => Lng.Elem("Camel");
	}
}
