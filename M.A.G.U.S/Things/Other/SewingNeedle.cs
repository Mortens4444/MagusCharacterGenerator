using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class SewingNeedle : Thing
{
	public override string Name => "Sewing needle";

	public override Money Price => new(0, 0, 3);

    public override string Description => "A small, thin piece of sharpened bone or steel with an eye for thread. Essential for repairing clothes, tents, and sacks.";
}
