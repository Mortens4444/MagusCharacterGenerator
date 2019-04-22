using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Clothes
{
	class Toga
	{
		public string Name => "Toga";

		public Money Price => new Money(0, 0, 120);

		public override string ToString() => Lng.Elem("Toga");
	}
}
