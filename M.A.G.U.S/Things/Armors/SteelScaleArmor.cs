using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class SteelScaleArmor : Armor
{
	public override string Name => "Steel scale armor";

	public override Money Price => new(20, 0, 0);

	public override int ArmorCheckPenalty => -2;

	public override int ArmorClass => 3;

	public override double Weight => 16;

    public override string Description => "Overlapping steel scales sewn onto a strong textile base. A dependable and widely used armor type that offers solid protection and is relatively easy to manufacture.";
}
