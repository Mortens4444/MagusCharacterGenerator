using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Other;

public class DaggerSleeve : Thing
{
	public override string Name => "Dagger sheath";

	public override Money Price => new(0, 1, 0);

    public override string Description => "A hidden sheath sewn into clothing or strapped to a limb, allowing a rogue or spy to carry a dagger concealed from view.";
}
