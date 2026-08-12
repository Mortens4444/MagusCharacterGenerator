using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Other;

public class Chalk : Thing
{
	public override Money Price => new(0, 0, 1);

    public override string Description => "A soft, white stone used to make temporary markings on stone, wood, or cloth. Handy for tallying scores or leaving secret signs.";
}
