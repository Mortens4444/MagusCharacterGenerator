using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class SilkEll : Thing
{
	public override string Name => "Silk, yard";

	public override Money Price => new(0, 8, 0);

    public override string Description => "A measure of rare, imported silk fabric. Extremely expensive and highly valued, used exclusively for the finest noble clothing or priestly robes.";
}
