using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class Blanket : Thing
{
	public override Money Price => new(0, 0, 80);

    public override string Description => "A heavy square of woven wool or coarse cloth. Provides necessary warmth for sleep, especially when sleeping rough beneath the stars.";
}
