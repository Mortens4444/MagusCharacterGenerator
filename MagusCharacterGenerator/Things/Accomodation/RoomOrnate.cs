using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Accomodation
{
	class RoomOrnate
	{
		public string Name => "Room, ornate";

		public Money Price => new Money(0, 0, 10);

		public override string ToString() => Lng.Elem("Room, ornate");
	}
}
