using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Travelling
{
	class Kogge
	{
		public string Name => "Kogge";

		public Money Price => new Money(200, 0, 0);

		public override string ToString() => Lng.Elem("Kogge");
	}
}
