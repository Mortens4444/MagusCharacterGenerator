using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class Fur
	{
		public string Name => "Fur";

		public Money Price => new Money(0, 6, 0);

		public override string ToString() => Lng.Elem("Fur");
	}
}
