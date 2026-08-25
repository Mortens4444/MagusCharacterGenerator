using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Food;

public class ButterKilo : Thing
{
	public override string Name => "Butter, kilo";

	public override Money Price => new(0, 0, 2);

    public override int HungerValue => 20;

    public override int PortionCount => 10;

    public override double Weight => 1.0;

    public override string Description => "A large, heavy measure of churned butter, pressed from rich milk. Used for cooking or spread upon bread, a valuable source of fat and flavour.";
}
