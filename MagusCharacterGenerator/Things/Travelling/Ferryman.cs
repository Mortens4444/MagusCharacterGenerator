using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Travelling
{
	class Ferryman
	{
		public string Name => "Ferryman";

		public Money Price => new Money(0, 0, 20);

		public override string ToString() => Lng.Elem("Ferryman");
	}
}
