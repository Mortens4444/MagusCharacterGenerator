using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Clothes;

public class CapeFur : Thing
{
	public override string Name => "Cloak, fur";

	public override Money Price => new(5, 0, 0);

    public override string Description => "A heavy, luxurious cloak lined or trimmed with the hide of wild beasts. It offers great warmth against the deepest winter cold and is a mark of wealth.";
}
