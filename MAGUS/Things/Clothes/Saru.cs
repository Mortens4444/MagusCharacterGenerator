using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Clothes;

public class Saru : Thing
{
	public override Money Price => new(0, 0, 3);

	override public string Name => "Shoestring sandals";

    public override string Description => "A long, wrapping garment made of light, finely dyed cloth. A style often seen in the exotic South, offering comfort and coolness in the heat.";
}
