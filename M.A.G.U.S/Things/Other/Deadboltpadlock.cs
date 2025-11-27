using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class Deadboltpadlock : Thing
{
	public override string Name => "Lock/padlock";

	public override Money Price => new(0, 3, 0);

    public override string Description => "A heavy, strong locking device that can be secured to a chest or door using a separate shackle. It offers respectable defense against simple tools.";
}
