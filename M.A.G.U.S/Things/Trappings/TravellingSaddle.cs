using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Trappings;

public class TravellingSaddle : Thing
{
	public override string Name => "Saddle, traveling";

	public override Money Price => new(0, 0, 150);

    public override string Description => "A lightweight and comfortable saddle built for long days of riding on common roads. It is cushioned and balanced to provide ease to both the rider and the steed.";
}
