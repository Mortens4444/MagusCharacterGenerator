using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Clothes
{
	class Sandals
	{
		public string Name => "Sandals";

		public Money Price => new Money(0, 0, 4);

		public override string ToString() => Lng.Elem("Sandals");
	}
}
