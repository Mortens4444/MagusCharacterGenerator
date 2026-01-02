using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Animals;

public class FalconHunting : Thing
{
	public override string Name => "Falcon, hunting";

	public override Money Price => new(8, 0, 0);

    public override string Description => "A noble bird of prey, painstakingly trained in the art of falconry. Used by lords and ladies to hunt small game, a hawk is both a deadly tool and a symbol of high status.";
}
