using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Animals;

public class Donkey : Thing
{
	public override Money Price => new(0, 7, 0);

    public override string Description => "A humble pack animal, renowned for its endurance and sure-footedness on mountain trails. Though small, it can carry heavy loads and costs less than a fine horse.";
}
