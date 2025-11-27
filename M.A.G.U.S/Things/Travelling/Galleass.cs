using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Travelling;

public class Galleass : Thing
{
	public override Money Price => new(800, 0, 0);

    public override string Description => "A massive warship that combines the sail power of a galley with heavy cannon emplacements. A formidable sight on the sea, capable of carrying numerous troops.";
}
