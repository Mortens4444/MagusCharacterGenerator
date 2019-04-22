using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class ParchmentSheets
	{
		public string Name => "Parchment sheets";

		public Money Price => new Money(0, 0, 15);

		public override string ToString() => Lng.Elem("Parchment sheets");
	}
}
