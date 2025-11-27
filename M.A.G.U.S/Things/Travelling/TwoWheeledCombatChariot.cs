using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Travelling;

public class TwoWheeledCombatChariot : Thing
{
	public override string Name => "Two-wheeled war chariot";

	public override Money Price => new(50, 0, 0);

    public override string Description => "A light, fast battle carriage drawn by two horses. It carries a warrior and a driver, used for skirmishing, harassment, and rapidly moving archers across the battlefield.";
}
