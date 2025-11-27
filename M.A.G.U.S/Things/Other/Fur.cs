using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class Fur : Thing
{
	public override Money Price => new(0, 6, 0);

    public override string Description => "The pelt of an animal, usually used as a lining for cold-weather clothing or as a soft throw on a bed.";
}
