using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Other;

public class OilForLamps : Thing
{
	public override string Name => "Oil, lamp";

	public override Money Price => new(0, 0, 3);

    public override string Description => "A flask of rendered fat or common vegetable oil, used as fuel for lamps and lampions.";
}
