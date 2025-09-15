using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class SewingNeedle : Thing
{
	public override string Name => "Sewing needle";

	public Money Price => new(0, 0, 3);
}
