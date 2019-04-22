using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Clothes
{
	class Coat
	{
		public string Name => "Coat";

		public Money Price => new Money(0, 2, 0);

		public override string ToString() => Lng.Elem("Coat");
	}
}
