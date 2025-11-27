using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Travelling;

public class Kogge : Thing
{
	public override Money Price => new(200, 0, 0);

    public override string Description => "A round, tubby merchant vessel with a single mast and high sides. Though slow, it is extremely stable and possesses a vast hold, making it the workhorse of Northern trade.";
}
