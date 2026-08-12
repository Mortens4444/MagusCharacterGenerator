using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Other;

public class TentMilitary : Thing
{
	public override string Name => "Tent, military";

	public override Money Price => new(3, 0, 0);

    public override string Description => "A standard, durable canvas tent, designed for quick pitching and sufficient to shelter two or three soldiers during a night's watch.";
}
