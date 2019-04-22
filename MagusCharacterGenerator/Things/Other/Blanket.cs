using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class Blanket
	{
		public string Name => "Blanket";

		public Money Price => new Money(0, 0, 80);

		public override string ToString() => Lng.Elem("Blanket");
	}
}
