using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Food
{
	class CommonSpice
	{
		public string Name => "Common spice";

		public Money Price => new Money(0, 0, 2);

		public override string ToString() => Lng.Elem("Common spice");
	}
}
