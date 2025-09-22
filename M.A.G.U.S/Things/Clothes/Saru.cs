using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Clothes;

public class Saru : Thing
{
	public override Money Price => new(0, 0, 3);

	override public string Name => "Shoestring sandals";
}
