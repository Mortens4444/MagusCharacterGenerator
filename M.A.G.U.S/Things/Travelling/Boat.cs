using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Travelling;

public class Boat : Thing
{
	public override string Name => "Boat";

	public override Money Price => new(5, 0, 0);

    public override string Description => "A simple wooden craft, small enough to be rowed or sailed by a few men. Used for short journeys on rivers, lakes, or coastal waters.";
}
