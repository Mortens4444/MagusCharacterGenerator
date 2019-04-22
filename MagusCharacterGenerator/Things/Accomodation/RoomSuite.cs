using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Accomodation
{
	class RoomSuite
	{
		public string Name => "Room, suite";

		public Money Price => new Money(0, 0, 30);

		public override string ToString() => Lng.Elem("Room, suite");
	}
}
