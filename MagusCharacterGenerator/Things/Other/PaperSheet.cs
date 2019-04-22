using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class PaperSheet
	{
		public string Name => "Paper, sheet";

		public Money Price => new Money(0, 0, 20);

		public override string ToString() => Lng.Elem("Paper, sheet");
	}
}
