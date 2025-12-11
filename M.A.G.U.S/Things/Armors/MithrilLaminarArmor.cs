using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class MithrilLaminarArmor : Armor
{
	public override string Name => "Mithril plate armor";

	public override Money Price => new(4000, 0, 0);

	public override int ArmorCheckPenalty => -1;

	public override int ArmorClass => 5;

	public override double Weight => 5;

    public override string Description => "Overlapping strips of lightweight Mithril, combining the strengths of plate and mail with incredible weight savings.";
}
