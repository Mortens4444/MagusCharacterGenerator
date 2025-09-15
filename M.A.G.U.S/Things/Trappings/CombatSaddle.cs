using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Trappings;

public class CombatSaddle : Thing
{
	public override string Name => "Combat saddle";

	public Money Price => new(0, 5, 0);
}
