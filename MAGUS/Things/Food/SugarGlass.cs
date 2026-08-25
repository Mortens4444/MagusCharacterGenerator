using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Food;

public class SugarGlass : Thing
{
	public override string Name => "Sugar, loaf";

	public override Money Price => new(0, 0, 5);

    public override int HungerValue => 5;

    public override string Description => "A small, fragile piece of hardened, refined sugar. A luxurious sweetmeat, more often used for decorative purpose than for common flavouring, and a status symbol.";
}
