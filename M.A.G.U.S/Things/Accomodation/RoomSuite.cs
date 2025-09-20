using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Accomodation;

public class RoomSuite : Thing
{
	public override string Name => "Room, suite";

	public override Money Price => new(0, 0, 30);
}
