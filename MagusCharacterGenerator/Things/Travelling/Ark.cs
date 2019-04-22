using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Travelling
{
	class Ark
	{
		public string Name => "Ark";

		public Money Price => new Money(50, 0, 0);

		public override string ToString() => Lng.Elem("Ark");
	}
}
