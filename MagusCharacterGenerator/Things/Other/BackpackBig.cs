using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class BackpackBig
	{
		public string Name => "Backpack, big";

		public Money Price => new Money(0, 0, 120);

		public override string ToString() => Lng.Elem("Backpack, big");
	}
}
