using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class Lampion
	{
		public string Name => "Lampion";

		public Money Price => new Money(0, 0, 1);

		public override string ToString() => Lng.Elem("Lampion");
	}
}
