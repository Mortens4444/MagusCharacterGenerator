using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Clothes
{
	class Cap
	{
		public string Name => "Cap";

		public Money Price => new Money(0, 0, 5);

		public override string ToString() => Lng.Elem("Cap");
	}
}
