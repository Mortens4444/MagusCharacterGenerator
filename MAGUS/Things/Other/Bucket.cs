using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Other;

public class Bucket : Thing
{
	public override Money Price => new(0, 1, 0);

    public override string Description => "A simple container of wood or iron, used for drawing water from a well or carrying liquids and small materials.";
}
