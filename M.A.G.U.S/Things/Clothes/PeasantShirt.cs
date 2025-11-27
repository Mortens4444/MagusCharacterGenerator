using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Clothes;

public class PeasantShirt : Thing
{
	public override string Name => "Peasant shirt";

	public override Money Price => new(0, 0, 5);

    public override string Description => "A coarse tunic or undershirt woven from rough wool or unbleached linen. It is durable, cheap, and the uniform of the common labourer.";
}
