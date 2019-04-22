using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Clothes
{
	class Shorts
	{
		public string Name => "Shorts";

		public Money Price => new Money(0, 0, 20);

		public override string ToString() => Lng.Elem("Shorts");
	}
}
