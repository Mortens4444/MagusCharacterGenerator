using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class TentSmall
	{
		public string Name => "Tent, small";

		public Money Price => new Money(0, 7, 0);

		public override string ToString() => Lng.Elem("Tent, small");
	}
}
