using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Animals;

public class HorsePony : Thing
{
	public override string Name => "Horse, pony";

	public override Money Price => new(0, 8, 0);

    public override string Description => "A small, robust breed, fit for children, servants, or those of shorter stature. They are tireless and require less fodder than their larger kin.";
}
