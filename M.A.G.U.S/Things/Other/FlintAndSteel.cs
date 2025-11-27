using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class FlintAndSteel : Thing
{
	public override string Name => "Flint and steel";

	public override Money Price => new(0, 0, 5);

    public override string Description => "The complete kit needed to start a fire: a piece of hard flint rock and a striker of steel, often carried with a piece of charred cloth.";
}
