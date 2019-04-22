using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Clothes
{
	class Pants
	{
		public string Name => "Pants";

		public Money Price => new Money(0, 0, 3);

		public override string ToString() => Lng.Elem("Pants");
	}
}
