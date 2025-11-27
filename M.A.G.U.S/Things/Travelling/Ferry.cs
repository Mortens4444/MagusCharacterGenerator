using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Travelling;

public class Ferry : Thing
{
	public override Money Price => new(0, 0, 10);

    public override string Description => "A broad, simple flatboat used to transport people, animals, and goods across a river or narrow strait. It relies on a strong rope or a boatman's skill to move from bank to bank.";
}
