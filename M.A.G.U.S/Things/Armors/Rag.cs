using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class Rag : Thing
{
	public override Money Price => new(0, 1, 0);

	public int MovementInhibitingFactor => 0;

	public int DamageSusceptiveValue => 1;

	public int Weight => 5;
}
