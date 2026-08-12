using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Clothes;

public class Vest : Thing
{
	public override Money Price => new(0, 0, 30);

    public override string Description => "A sleeveless garment worn over a shirt but beneath a coat. It offers extra warmth to the torso and can be richly decorated in courtly life.";
}
