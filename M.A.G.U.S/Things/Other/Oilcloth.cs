using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class Oilcloth : Thing
{
	public override Money Price => new(0, 0, 25);

    public override string Description => "A sheet of canvas or heavy fabric treated with oil or wax to make it waterproof. Used to cover goods, shelter from rain, or serve as a makeshift groundsheet.";
}
