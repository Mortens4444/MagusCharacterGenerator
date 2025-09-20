using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Trappings;

public class TravellingSaddle : Thing
{
	public override string Name => "Saddle, traveling";

	public override Money Price => new(0, 0, 150);
}
