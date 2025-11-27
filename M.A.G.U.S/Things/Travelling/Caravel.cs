using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Travelling;

public class Caravel : Thing
{
	public override Money Price => new(250, 0, 0);

    public override string Description => "A swift, graceful sailing ship with lateen (triangular) sails. Though smaller than a galleon, it is excellent for long-distance exploration and crossing the open sea quickly.";
}
