using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Travelling
{
	class Galeon
	{
		public string Name => "Galeon";

		public Money Price => new Money(1800, 0, 0);

		public override string ToString() => Lng.Elem("Galeon");
	}
}
