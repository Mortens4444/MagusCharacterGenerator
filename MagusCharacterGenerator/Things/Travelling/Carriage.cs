using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Travelling
{
	class Carriage
	{
		public string Name => "Carriage";

		public Money Price => new Money(15, 0, 0);

		public override string ToString() => Lng.Elem("Carriage");
	}
}
