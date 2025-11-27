using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Food;

public class GameMeatPortion : Thing
{
	public override string Name => "Game meat, portion";

	public override Money Price => new(0, 0, 4);

    public override string Description => "A single serving of wild flesh, such as venison, boar, or fowl taken from the hunt. Richer in flavour than common livestock, and often reserved for feast days.";
}
