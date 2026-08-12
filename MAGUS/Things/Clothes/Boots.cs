using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Clothes;

public class Boots : Thing
{
	public override Money Price => new(0, 0, 10);

    public override string Description => "Sturdy leather footwear extending above the ankle. Necessary for travel on rough roads and offering greater protection than simple shoes.";
}
