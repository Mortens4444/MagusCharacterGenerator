using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Other;

public class Flask : Thing
{
	public override Money Price => new(0, 0, 4);

    public override string Description => "A small, flat bottle of glass, ceramic, or leather, usually used for carrying strong spirits, oil, or potent liquid medicines.";
}
