using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class FishingHook
	{
		public string Name => "Fishing hook";

		public Money Price => new Money(0, 0, 1);

		public override string ToString() => Lng.Elem("Fishing hook");
	}
}
