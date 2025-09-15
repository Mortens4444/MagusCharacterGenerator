using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class MitrillFullPlate : Thing
{
	public override string Name => "Mitrill full plate";

	public Money Price => new(20000, 0, 0);

	public int MovementInhibitingFactor => -4;

	public int DamageSusceptiveValue => 8;

	public int Weight => 10;
}
