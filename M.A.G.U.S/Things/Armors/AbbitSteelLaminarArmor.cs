using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class AbbitSteelLaminarArmor : Thing
{
	public override string Name => "Abbit-steel plate armor";

	public override Money Price => new(100, 0, 0);

	public int MovementInhibitingFactor => -2;

	public int DamageSusceptiveValue => 4;

	public int Weight => 7;
}
