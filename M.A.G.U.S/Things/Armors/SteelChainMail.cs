using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class SteelChainmail : Armor
{
	public override string Name => "Steel chainmail";

	public override Money Price => new(12, 0, 0);

	public override int ArmorCheckPenalty => -1;

	public override int ArmorClass => 3;

	public override double Weight => 20;

    public override string Description => "The classic mail shirt of interlocking steel rings. Offers excellent defense against slicing weapons and is flexible, making it the standard protection for most professional soldiers.";
}
