using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class HardenedLeatherArmor : Thing
{
	public override string Name => "Hardened leather";

	public override Money Price => new(0, 5, 0);

	public int MovementInhibitingFactor => -2;

	public int DamageSusceptiveValue => 2;

	public override double Weight => 7;

    public override string Description => "Thick leather that has been boiled or treated with wax and oil to make it nearly as tough as wood. Offers good defense against bludgeons and slashes, yet remains relatively light and supple.";
}
