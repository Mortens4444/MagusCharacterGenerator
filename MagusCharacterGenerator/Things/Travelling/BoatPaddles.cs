using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Travelling
{
	class BoatPaddles
	{
		public string Name => "Boat paddles";

		public Money Price => new Money(0, 1, 0);

		public override string ToString() => Lng.Elem("Boat paddles");
	}
}
