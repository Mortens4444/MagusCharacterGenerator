using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Clothes;

public class Vest : Thing
{
	public override Money Price => new(0, 0, 30);

    public override string Description => "A sleeveless garment worn over a shirt but beneath a coat. It offers extra warmth to the torso and can be richly decorated in courtly life.";
}
