using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Food;

public class EggsDozen : Thing
{
	public override string Name => "Eggs, dozen";

	public override Money Price => new(0, 0, 1);
}
