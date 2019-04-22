using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class Hatchet
	{
		public string Name => "Hatchet";

		public Money Price => new Money(0, 2, 0);

		public override string ToString() => Lng.Elem("Hatchet");
	}
}
