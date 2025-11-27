using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class FishHook : Thing
{
	public override string Name => "Fish hook";

	public override Money Price => new(0, 0, 1);

    public override string Description => "A small, barbed iron hook attached to a line. Used to catch fish for sustenance, a vital tool for any wilderness survivor.";
}
