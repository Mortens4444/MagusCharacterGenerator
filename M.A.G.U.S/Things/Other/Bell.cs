using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class Bell : Thing
{
	public override Money Price => new(0, 0, 10);

    public override string Description => "A small, cast bronze bell. Used to ring a warning, call attention, mark the passage of time, or worn by livestock to track their movements.";
}
