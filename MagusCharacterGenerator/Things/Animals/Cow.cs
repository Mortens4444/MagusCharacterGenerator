using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Animals
{
	class Cow
	{
		public string Name => "Cow";

		public Money Price => new Money(0, 8, 0);

		public override string ToString() => Lng.Elem("Cow");
	}
}
