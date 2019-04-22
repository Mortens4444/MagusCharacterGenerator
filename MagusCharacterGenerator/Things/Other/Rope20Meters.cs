using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class Rope20Meters
	{
		public string Name => "Rope (20 meters)";

		public Money Price => new Money(0, 0, 30);

		public override string ToString() => Lng.Elem("Rope (20 meters)");
	}
}
