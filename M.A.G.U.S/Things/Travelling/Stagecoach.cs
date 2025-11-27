using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Travelling;

public class Stagecoach : Thing
{
	public override Money Price => new(20, 0, 0);

    public override string Name => "Wagon";

    public override string Description => "A heavy, enclosed carriage that runs a fixed route between major towns and cities, carrying both passengers and important mail for a set fee.";
}
