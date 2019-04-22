using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class BarrelSmall
	{
		public string Name => "Barrel, small";

		public Money Price => new Money(0, 2, 0);

		public override string ToString() => Lng.Elem("Barrel, small");
	}
}
