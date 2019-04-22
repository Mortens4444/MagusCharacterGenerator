using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class BeltHolster
	{
		public string Name => "Belt holster";

		public Money Price => new Money(0, 0, 70);

		public override string ToString() => Lng.Elem("Belt holster");
	}
}
