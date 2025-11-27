using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class BronzeBreastPlate : Thing
{
	public override string Name => "Bronze breastplate";

	public override Money Price => new(60, 0, 0);

	public int MovementInhibitingFactor => -4;

	public int DamageSusceptiveValue => 3;

	public override double Weight => 20;

    public override string Description => "A thick bronze plate cast or hammered to protect the chest. Less resilient than steel but more affordable, it serves as the core defense for guards or soldiers in lands where iron is scarce.";
}
