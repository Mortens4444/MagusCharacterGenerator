using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class Oilcloth
	{
		public string Name => "Oilcloth";

		public Money Price => new Money(0, 0, 25);

		public override string ToString() => Lng.Elem("Oilcloth");
	}
}
