using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class SealingWax
	{
		public string Name => "Sealing wax";

		public Money Price => new Money(0, 0, 10);

		public override string ToString() => Lng.Elem("Sealing wax");
	}
}
