using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class Earthenware
	{
		public string Name => "Earthenware";

		public Money Price => new Money(0, 0, 5);

		public override string ToString() => Lng.Elem("Earthenware");
	}
}
