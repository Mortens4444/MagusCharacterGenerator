using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Travelling;

public class BoatPaddles : Thing
{
	public override string Name => "Boat oar";

	public override Money Price => new(0, 1, 0);

    public override string Description => "Simple, flat blades of wood on long handles, used to propel a small boat or canoe forward when the wind is absent or the waters are shallow.";
}
