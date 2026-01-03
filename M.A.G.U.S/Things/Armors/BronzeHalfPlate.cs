using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class BronzeHalfPlate : HalfPlate
{
	public override string Name => "Bronze half plate";

	public override Money Price => new(100, 0, 0);

	public override int ArmorCheckPenalty => -6;

	public override int ArmorClass => 4;

	public override double Weight => 35;

    public override string Description => "Bronze plate armour focused on protecting the torso and upper limbs. A heavier, older style of defense, often borne by veterans who rely on their bronze weapons and gear.";
}
