using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class TentGreat
	{
		public string Name => "Tent, great";

		public Money Price => new Money(1, 0, 0);

		public override string ToString() => Lng.Elem("Tent, great");
	}
}
