using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class SteelBreastPlate : Armor
{
	public override string Name => "Steel breastplate";

	public override Money Price => new(80, 0, 0);

	public override int ArmorCheckPenalty => -4;

	public override int ArmorClass => 4;

	public override double Weight => 18;

    public override string Description => "A common but effective steel plate, covering the chest and often the abdomen. It is the mainstay of heavy infantry, offering a resilient shield against frontal assault.";
}
