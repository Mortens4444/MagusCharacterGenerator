using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Travelling;

public class TwoWheeledCombatChariot : Thing
{
	public override string Name => "Two wheeled combat chariot";

	public Money Price => new(50, 0, 0);
}
