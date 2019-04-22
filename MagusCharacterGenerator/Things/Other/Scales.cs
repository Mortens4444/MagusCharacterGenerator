using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class Scales
	{
		public string Name => "Scales";

		public Money Price => new Money(0, 0, 45);

		public override string ToString() => Lng.Elem("Scales");
	}
}
