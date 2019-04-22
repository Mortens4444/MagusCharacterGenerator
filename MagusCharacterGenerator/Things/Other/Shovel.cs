using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class Shovel
	{
		public string Name => "Shovel";

		public Money Price => new Money(0, 0, 8);

		public override string ToString() => Lng.Elem("Shovel");
	}
}
