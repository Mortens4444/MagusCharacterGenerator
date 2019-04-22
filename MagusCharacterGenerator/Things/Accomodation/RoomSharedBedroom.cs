using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Accomodation
{
	class RoomSharedBedroom
	{
		public string Name => "Room, shared bedroom";

		public Money Price => new Money(0, 0, 2);

		public override string ToString() => Lng.Elem("Room, shared bedroom");
	}
}
