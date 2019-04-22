using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class Hammer
	{
		public string Name => "Hammer";

		public Money Price => new Money(0, 0, 10);

		public override string ToString() => Lng.Elem("Hammer");
	}
}
