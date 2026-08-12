using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Other;

public class Candle : Thing
{
	public override Money Price => new(0, 0, 2);

    public override string Description => "A small wick dipped in wax or tallow, providing a dim, transient light indoors. It is consumed quickly but is safer and cleaner than a sputtering oil lamp.";
}
