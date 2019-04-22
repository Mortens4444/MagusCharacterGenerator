using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Travelling
{
	class TravelingCartWithTwoWheels
	{
		public string Name => "Traveling cart with two wheels";

		public Money Price => new Money(5, 0, 0);

		public override string ToString() => Lng.Elem("Traveling cart with two wheels");
	}
}
