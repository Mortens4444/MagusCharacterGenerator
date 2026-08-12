using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Armors;

public class SteelLaminarArmor : LaminarArmor
{
	public override string Name => "Steel plate armor";

	public override Money Price => new(40, 0, 0);

	public override int ArmorCheckPenalty => -3;

	public override int ArmorClass => 3;

	public override double Weight => 16;

    public override string Description => "Protection made of horizontal steel strips, riveted or laced together. It offers superior deflection against blunt force and is highly durable.";
}
