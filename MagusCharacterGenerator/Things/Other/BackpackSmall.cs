using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class BackpackSmall
	{
		public string Name => "Backpack, small";

		public Money Price => new Money(0, 0, 90);

		public override string ToString() => Lng.Elem("Backpack, small");
	}
}
