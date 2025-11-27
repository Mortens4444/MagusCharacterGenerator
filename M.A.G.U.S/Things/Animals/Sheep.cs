using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Animals;

public class Sheep : Thing
{
	public override Money Price => new(0, 4, 0);

    public override string Description => "The backbone of the cloth trade, raised primarily for its fine wool. They move in great flocks, requiring a shepherd and guard dogs to protect them from wolves and brigands.";
}
