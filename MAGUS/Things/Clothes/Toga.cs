using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Clothes;

public class Toga : Thing
{
	public override Money Price => new(0, 0, 120);

    public override string Description => "A voluminous outer robe draped elegantly about the body, recalling the dress of ancient empires. It signifies learning or high, dignified rank.";
}
