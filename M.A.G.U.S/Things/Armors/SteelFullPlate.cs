using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class SteelFullPlate : Armor
{
	public override string Name => "Steel full plate";

	public override Money Price => new(200, 0, 0);

	public override int ArmorCheckPenalty => -8;

	public override int ArmorClass => 6;

	public override double Weight => 35;

    public override string Description => "A complete, heavy harness of well-made steel plates. This heavy defence turns aside most common attacks but requires great strength and stamina to wear and fight effectively in.";
}
