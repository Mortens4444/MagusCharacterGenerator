using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class MithrilScaleArmor : Armor
{
	public override string Name => "Mithril scale armor";

	public override Money Price => new(2000, 0, 0);

	public override int ArmorCheckPenalty => 0;

	public override int ArmorClass => 5;

	public override double Weight => 5;

    public override string Description => "Scales made of Mithril, sewn onto a cloth backing. A supremely light and flexible defense that guards against slashes with magic-touched resilience.";
}
