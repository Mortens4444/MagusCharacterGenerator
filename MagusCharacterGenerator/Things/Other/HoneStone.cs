using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class HoneStone
	{
		public string Name => "Hone stone";

		public Money Price => new Money(0, 0, 1);

		public override string ToString() => Lng.Elem("Hone stone");
	}
}
