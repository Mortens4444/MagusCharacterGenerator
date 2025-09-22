using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Food;

public class Loree : Thing
{
	public override Money Price => new(0, 0, 1);

    public override string Name => "Cheap wine";
}
