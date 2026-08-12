using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Other;

public class Shovel : Thing
{
	public override Money Price => new(0, 0, 8);

    public override string Description => "A long-handled tool with a broad blade, used for digging earth, moving gravel, or clearing snow.";
}
