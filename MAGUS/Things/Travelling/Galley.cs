using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Travelling;

public class Galley : Thing
{
	public override Money Price => new(300, 0, 0);

    public override string Description => "A long, narrow warship propelled primarily by numerous rows of oarsmen. Swift and effective in coastal waters, capable of rapidly closing with an enemy vessel.";
}
