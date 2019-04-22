using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Travelling
{
	class GalleonPaddles
	{
		public string Name => "Galleon paddles";

		public Money Price => new Money(0, 3, 0);

		public override string ToString() => Lng.Elem("Galleon paddles");
	}
}
