using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Accomodation;

public class RoomSuite : Thing
{
	public override string Name => "Room, suite";

	public override Money Price => new(0, 0, 30);

    public override string Description => "Lord's Suite\r\n\r\nThe Grandest Lodging. A spacious arrangement with separate chambers for sleeping and taking meals, often including its own small, private latrine. Furnished with the finest oak and velvet, this suite offers security, silence, and all the comforts one might desire, reserved for the truly distinguished guest.";
}
