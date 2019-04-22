using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Travelling
{
	class Landau
	{
		public string Name => "Landau";

		public Money Price => new Money(150, 0, 0);

		public override string ToString() => Lng.Elem("Landau");
	}
}
