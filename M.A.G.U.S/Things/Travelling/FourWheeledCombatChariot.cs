using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Travelling;

public class FourWheeledCombatChariot : Thing
{
	public override string Name => "Four-wheeled war chariot";

	public override Money Price => new(100, 0, 0);

    public override string Description => "A heavy, iron-shod battle vehicle built upon four wheels for stability and pulled by powerful horses. It carries multiple armoured warriors and is used to break enemy lines with brute force.";
}
