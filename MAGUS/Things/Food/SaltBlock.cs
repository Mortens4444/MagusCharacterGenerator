using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Food;

public class SaltBlock : Thing
{
	public override string Name => "Salt, block";

	public override Money Price => new(0, 0, 1);

    public override string Description => "A large, necessary block of coarse salt. Essential for preserving meats and fish, and a vital trading commodity in regions far from the sea.";
}
