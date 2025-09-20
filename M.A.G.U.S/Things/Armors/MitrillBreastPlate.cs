using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class MitrillBreastPlate : Thing
{
	public override string Name => "Mitrill breast plate";

	public override Money Price => new(8000, 0, 0);

	public int MovementInhibitingFactor => -1;

	public int DamageSusceptiveValue => 6;

	public int Weight => 6;
}
