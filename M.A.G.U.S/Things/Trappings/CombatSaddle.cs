using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Trappings;

public class CombatSaddle : Thing
{
	public override string Name => "Saddle, war";

	public override Money Price => new(0, 5, 0);

    public override string Description => "A sturdy, high-cantled saddle built for the rigours of warfare. It provides a deep, secure seat and high pommel to prevent a warrior from being unseated by the shock of combat.";
}
