using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class BrigandineArmor : Armor
{
	public override string Name => "Brigandine armor";

	public override Money Price => new(4, 0, 0);

	public override int ArmorCheckPenalty => -2;

	public override int ArmorClass => 3;

	public override double Weight => 15;

    public override string Description => "A flexible cuirass of heavy cloth or canvas, inside of which are riveted many small metal plates. It offers respectable defense while appearing deceptively simple and granting stealthier movement than full plate.";
}
