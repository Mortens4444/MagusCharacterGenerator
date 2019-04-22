using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Travelling
{
	class SedanChair
	{
		public string Name => "Sedan chair";

		public Money Price => new Money(10, 0, 0);

		public override string ToString() => Lng.Elem("Sedan chair");
	}
}
