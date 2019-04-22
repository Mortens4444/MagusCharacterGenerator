using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class Ink
	{
		public string Name => "Ink";

		public Money Price => new Money(0, 0, 20);

		public override string ToString() => Lng.Elem("Ink");
	}
}
