using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class Hose
	{
		public string Name => "Hose";

		public Money Price => new Money(0, 0, 3);

		public override string ToString() => Lng.Elem("Hose");
	}
}
