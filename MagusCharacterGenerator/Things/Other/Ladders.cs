using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class Ladders
	{
		public string Name => "Ladders";

		public Money Price => new Money(0, 0, 25);

		public override string ToString() => Lng.Elem("Ladders");
	}
}
