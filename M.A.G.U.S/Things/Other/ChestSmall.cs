using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class ChestSmall : Thing
{
	public override string Name => "Chest, small";

	public override Money Price => new(0, 3, 0);

    public override string Description => "A small, locked box, often banded in metal. Used to secure coins, jewels, or personal letters from prying eyes.";
}
