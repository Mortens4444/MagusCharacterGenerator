using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class FishingNet
	{
		public string Name => "Fishing net";

		public Money Price => new Money(0, 0, 80);

		public override string ToString() => Lng.Elem("Fishing net");
	}
}
