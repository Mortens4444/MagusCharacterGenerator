using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Other;

public class ClimbingSpikes : Thing
{
	public override string Name => "Climbing spikes";

	public override Money Price => new(0, 0, 3);

    public override string Description => "Iron spikes or hooks that attach to the boots, allowing one to gain purchase on sheer ice, rock, or rough wooden walls during ascent.";
}
