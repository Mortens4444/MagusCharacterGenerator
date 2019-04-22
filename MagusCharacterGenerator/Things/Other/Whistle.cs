using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class Whistle
	{
		public string Name => "Whistle";

		public Money Price => new Money(0, 2, 0);

		public override string ToString() => Lng.Elem("Whistle");
	}
}
