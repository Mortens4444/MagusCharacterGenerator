using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class FireSteel : Thing
{
	public override string Name => "Fire starter";

	public override Money Price => new(0, 0, 10);

    public override string Description => "A hard piece of steel used to strike against flint, yielding a spark to start a fire. A necessity for any who travel into the wild.";
}
