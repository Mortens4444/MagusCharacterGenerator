using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Food;

public class Liqueur : Thing
{
	public override Money Price => new(0, 0, 6);

    public override int HungerValue => 5;

    public override string Description => "A sweet, heavily flavoured spirit, often distilled with herbs, fruits, or spices. Used for medicinal purposes or as a digestif after a rich, heavy meal.";
}
