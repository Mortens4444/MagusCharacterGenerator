using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class BackpackLarge : Thing
{
	public override string Name => "Backpack, large";

	public override Money Price => new(0, 0, 120);

    public override string Description => "A sturdy satchel of thick canvas or leather, reinforced with straps. It is built to carry a great load of provisions, tools, or treasures upon a man's back.";
}
