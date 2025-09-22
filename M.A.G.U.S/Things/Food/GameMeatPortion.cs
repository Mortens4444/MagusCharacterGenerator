using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Food;

public class GameMeatPortion : Thing
{
	public override string Name => "Game meat, portion";

	public override Money Price => new(0, 0, 4);
}
