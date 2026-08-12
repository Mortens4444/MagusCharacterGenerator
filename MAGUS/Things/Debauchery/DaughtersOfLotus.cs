using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Debauchery;

public class DaughtersOfLotus : Thing
{
	public override string Name => "Daughters of the Lotus";

	public override Money Price => new(1, 0, 0);

    public override string Description => "Women of an exotic and secretive order, specializing in healing, poisons, and subtle manipulation. They are often beautifully adorned and skilled in the art of persuasion. They move through noble courts and bazaars, their true motives hidden behind painted smiles and delicate silks.";
}
