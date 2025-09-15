using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class BrigandineArmor : Thing
{
	public override string Name => "Brigandine armor";

	public Money Price => new(4, 0, 0);

	public int MovementInhibitingFactor => -2;

	public int DamageSusceptiveValue => 3;

	public int Weight => 15;
}
