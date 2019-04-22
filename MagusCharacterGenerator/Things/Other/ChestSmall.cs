using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class ChestSmall
	{
		public string Name => "Chest, small";

		public Money Price => new Money(0, 3, 0);

		public override string ToString() => Lng.Elem("Chest, small");
	}
}
