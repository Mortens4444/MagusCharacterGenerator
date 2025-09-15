using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class Deadboltpadlock : Thing
{
	public override string Name => "Deadbolt/padlock";

	public Money Price => new(0, 3, 0);
}
