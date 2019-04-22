using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Travelling
{
	class Sail
	{
		public string Name => "Sail";

		public Money Price => new Money(0, 2, 0);

		public override string ToString() => Lng.Elem("Sail");
	}
}
