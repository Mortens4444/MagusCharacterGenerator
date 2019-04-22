using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Travelling
{
	class Caravel
	{
		public string Name => "Caravel";

		public Money Price => new Money(250, 0, 0);

		public override string ToString() => Lng.Elem("Caravel");
	}
}
