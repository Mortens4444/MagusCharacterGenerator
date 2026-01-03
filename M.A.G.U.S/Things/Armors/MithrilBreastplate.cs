using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class MithrilBreastplate : Breastplate
{
	public override string Name => "Mithril breastplate";

	public override Money Price => new(8000, 0, 0);

	public override int ArmorCheckPenalty => -1;

	public override int ArmorClass => 6;

	public override double Weight => 6;

    public override string Description => "A breastplate forged from Mithril, the legendary light metal. It offers defense rivalling the heaviest steel, yet feels light as silk upon the body, prized by all warriors.";
}
