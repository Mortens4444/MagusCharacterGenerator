using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class BarrelBig
	{
		public string Name => "Barrel, big";

		public Money Price => new Money(0, 4, 0);

		public override string ToString() => Lng.Elem("Barrel, big");
	}
}
