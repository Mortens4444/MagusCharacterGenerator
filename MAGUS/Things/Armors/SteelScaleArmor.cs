using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Armors;

public class SteelScaleArmor : ScaleArmor
{
	public override string Name => "Steel scale armor";

	public override Money Price => new(20, 0, 0);

	public override int ArmorCheckPenalty => -2;

	public override int ArmorClass => 3;

	public override double Weight => 16;

    public override string Description => "Overlapping steel scales sewn onto a strong textile base. A dependable and widely used armor type that offers solid protection and is relatively easy to manufacture.";
}
