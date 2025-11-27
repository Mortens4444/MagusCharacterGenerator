using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class BeltHolster : Thing
{
	public override string Name => "Belt pouch";

	public override Money Price => new(0, 0, 70);

    public override string Description => "A leather loop or sheath designed to hang from the belt, often used to secure a small weapon, flask, or tool near to hand.";
}
