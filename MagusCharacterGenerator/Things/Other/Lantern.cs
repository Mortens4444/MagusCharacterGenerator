using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class Lantern
	{
		public string Name => "Lantern";

		public Money Price => new Money(0, 0, 10);

		public override string ToString() => Lng.Elem("Lantern");
	}
}
