using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class MithrilChainmail : Armor
{
	public override string Name => "Mithril chainmail";

	public override Money Price => new(1200, 0, 0);

	public override int ArmorCheckPenalty => 0;

	public override int ArmorClass => 5;

	public override double Weight => 10;

    public override string Description => "Mail crafted from Mithril rings. It provides extraordinary protection for its near-negligible weight, allowing the wearer to move with speed and tireless grace.";
}
