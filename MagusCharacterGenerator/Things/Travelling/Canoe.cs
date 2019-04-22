using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Travelling
{
	class Canoe
	{
		public string Name => "Canoe";

		public Money Price => new Money(7, 0, 0);

		public override string ToString() => Lng.Elem("Canoe");
	}
}
