using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Accomodation
{
    public class RoomWithSeparateBed : Thing
    {
		public override string Name => "Room, separate bed";

		public override Money Price => new(0, 0, 5);
	}
}
