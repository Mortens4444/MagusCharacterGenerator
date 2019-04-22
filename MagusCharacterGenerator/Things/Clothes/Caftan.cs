using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Clothes
{
	class Caftan
	{
		public string Name => "Caftan";

		public Money Price => new Money(0, 5, 0);

		public override string ToString() => Lng.Elem("Caftan");
	}
}
