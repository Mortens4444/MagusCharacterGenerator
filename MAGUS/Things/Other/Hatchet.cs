using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Other;

public class Hatchet : Thing
{
	public override Money Price => new(0, 2, 0);

    public override string Description => "A small, one-handed axe. Useful for chopping firewood, clearing light brush, or as an emergency tool and weapon.";
}
