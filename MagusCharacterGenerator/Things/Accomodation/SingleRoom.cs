using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Accomodation
{
	class SingleRoom
	{
		public string Name => "Single room";

		public Money Price => new Money(0, 0, 7);

		public override string ToString() => Lng.Elem("Single room");
	}
}
