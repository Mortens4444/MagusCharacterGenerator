using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Travelling;

public class Landau : Thing
{
	public override Money Price => new(150, 0, 0);

    public override string Description => "A heavy, finely sprung, four-wheeled carriage, often with a folding roof. Reserved for the most distinguished nobles, offering comfort and luxury during their brief journeys.";
}
