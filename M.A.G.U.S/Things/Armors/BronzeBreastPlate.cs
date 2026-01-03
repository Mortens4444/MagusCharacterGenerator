using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class BronzeBreastPlate : Breastplate
{
	public override string Name => "Bronze breastplate";

	public override Money Price => new(60, 0, 0);

	public override int ArmorCheckPenalty => -4;

	public override int ArmorClass => 3;

	public override double Weight => 20;

    public override string Description => "A thick bronze plate cast or hammered to protect the chest. Less resilient than steel but more affordable, it serves as the core defense for guards or soldiers in lands where iron is scarce.";
}
