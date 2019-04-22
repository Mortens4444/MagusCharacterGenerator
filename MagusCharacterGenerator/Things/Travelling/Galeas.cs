using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Travelling
{
	class Galeas
	{
		public string Name => "Galeas";

		public Money Price => new Money(800, 0, 0);

		public override string ToString() => Lng.Elem("Galeas");
	}
}
