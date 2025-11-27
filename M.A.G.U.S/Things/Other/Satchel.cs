using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class Satchel : Thing
{
	public override Money Price => new(0, 0, 40);

    public override string Description => "A small leather or heavy cloth bag with a shoulder strap. Used for carrying papers, small tools, and other personal items.";
}
