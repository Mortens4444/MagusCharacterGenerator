using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Animals;

public class Pig : Thing
{
	public override Money Price => new(0, 3, 0);

    public override string Description => "A rooting creature valued for its bacon and lard. They are often kept in sties near the village, and their consumption provides vital sustenance during the cold months.";
}
