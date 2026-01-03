using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class BronzeLaminarArmor : LaminarArmor
{
	public override string Name => "Bronze lamellar armor";

	public override Money Price => new(30, 0, 0);

	public override int ArmorCheckPenalty => -3;

	public override int ArmorClass => 2;

	public override double Weight => 18;

    public override string Description => "Overlapping strips of bronze metal, offering a compromise between the sturdiness of plate and the flexibility of mail. Common among older legions and city watches.";
}
