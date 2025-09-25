using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Accomodation;

public class SingleRoom : Thing
{
	public override string Name => "Room, single";

	public override Money Price => new(0, 0, 7);
}
