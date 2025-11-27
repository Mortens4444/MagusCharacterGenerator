using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Clothes;

public class WaistBelt : Thing
{
	public override string Name => "Girdle";

	public override Money Price => new(0, 0, 5);

    public override string Description => "A sturdy girdle worn tightly about the waist, primarily used to secure weapons, tools, or heavy pouches of coin.";
}
