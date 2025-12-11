using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class HardenedLeatherArmor : Armor
{
	public override string Name => "Hardened leather";

	public override Money Price => new(0, 5, 0);

	public override int ArmorCheckPenalty => -2;

	public override int ArmorClass => 2;

	public override double Weight => 7;

    public override string Description => "Thick leather that has been boiled or treated with wax and oil to make it nearly as tough as wood. Offers good defense against bludgeons and slashes, yet remains relatively light and supple.";
}
