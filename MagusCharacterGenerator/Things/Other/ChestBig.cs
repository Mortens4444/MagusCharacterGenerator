using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class ChestBig
	{
		public string Name => "Chest, big";

		public Money Price => new Money(0, 6, 0);

		public override string ToString() => Lng.Elem("Chest, big");
	}
}
