using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class SilkEll
	{
		public string Name => "Silk, ell";

		public Money Price => new Money(0, 8, 0);

		public override string ToString() => Lng.Elem("Silk, ell");
	}
}
