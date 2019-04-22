using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Food
{
	class WineCup
	{
		public string Name => "Wine, cup";

		public Money Price => new Money(0, 0, 1);

		public override string ToString() => Lng.Elem("Wine, cup");
	}
}
