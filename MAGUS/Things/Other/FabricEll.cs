using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Other;

public class FabricEll : Thing
{
	public override string Name => "Cloth, yard";

	public override Money Price => new(0, 0, 30);

    public override string Description => "A measure of woven cloth, typically two to three feet in length. Used as a standard unit when buying and selling textiles.";
}
