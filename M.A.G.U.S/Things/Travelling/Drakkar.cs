using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Travelling;

public class Drakkar : Thing
{
	public override Money Price => new(300, 0, 0);

    public override string Description => "A long, shallow-draft ship with a single sail and many oars, instantly recognizable by its carved beast head on the prow. The fearsome longship of the Northmen, swift in raid and conquest.";
}
