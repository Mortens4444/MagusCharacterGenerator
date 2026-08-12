using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Other;

public class TentSmall : Thing
{
	public override string Name => "Tent, small";

	public override Money Price => new(0, 7, 0);

    public override string Description => "A humble, lightweight tent sufficient for one or two persons. Easily carried and quick to erect for simple travel.";
}
