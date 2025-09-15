using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class AbbitSteelBreastPlate : Thing
{
	public override string Name => "Abbit steel breast plate";

	public Money Price => new(200, 0, 0);

	public int MovementInhibitingFactor => -2;

	public int DamageSusceptiveValue => 8;

	public int Weight => 12;
}
