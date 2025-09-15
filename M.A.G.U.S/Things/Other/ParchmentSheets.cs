using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class ParchmentSheets : Thing
{
	public override string Name => "Parchment sheets";

	public Money Price => new(0, 0, 15);
}
