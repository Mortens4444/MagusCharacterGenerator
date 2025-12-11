using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class RingArmor : Armor
{
	public override string Name => "Ring mail";

	public override Money Price => new(2, 0, 0);

	public override int ArmorCheckPenalty => -1;

	public override int ArmorClass => 1;

	public override double Weight => 12;

    public override string Description => "A garment, often leather or thick cloth, onto which large metal rings are individually stitched or linked. Provides minimal protection compared to true mail, but is cheap and quick to repair.";
}
