using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class ChainMeter
	{
		public string Name => "Chain, meter";

		public Money Price => new Money(0, 0, 5);

		public override string ToString() => Lng.Elem("Chain, meter");
	}
}
