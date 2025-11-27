using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Clothes;

public class Cap : Thing
{
	public override string Name => "Cap";

	public override Money Price => new(0, 0, 5);

    public override string Description => "A simple covering for the head, usually made of wool or soft felt. It provides warmth and modesty, worn by all ranks of folk.";
}
