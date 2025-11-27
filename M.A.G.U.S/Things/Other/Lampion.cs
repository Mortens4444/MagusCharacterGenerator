using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class Lampion : Thing
{
	public override Money Price => new(0, 0, 1);

    public override string Description => "A small, portable light source, often a simple oil lamp protected by a glass or horn covering to prevent the flame from being extinguished by the wind.";
}
