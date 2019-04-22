using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Travelling
{
	class Galley
	{
		public string Name => "Galley";

		public Money Price => new Money(300, 0, 0);

		public override string ToString() => Lng.Elem("Galley");
	}
}
