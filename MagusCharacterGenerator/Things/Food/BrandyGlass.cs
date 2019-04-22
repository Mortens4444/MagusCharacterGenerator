using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Food
{
	class BrandyGlass
	{
		public string Name => "Brandy, glass";

		public Money Price => new Money(0, 0, 2);

		public override string ToString() => Lng.Elem("Brandy, glass");
	}
}
