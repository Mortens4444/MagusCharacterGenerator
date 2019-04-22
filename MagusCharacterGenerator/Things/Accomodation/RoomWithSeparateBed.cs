using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Accomodation
{
	class RoomWithSeparateBed
	{
		public string Name => "Room with separate bed";

		public Money Price => new Money(0, 0, 5);

		public override string ToString() => Lng.Elem("Room with separate bed");
	}
}
