using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Travelling;

public class Galleass : Thing
{
	public override Money Price => new(800, 0, 0);

    public override string Description => "A massive warship that combines the sail power of a galley with heavy cannon emplacements. A formidable sight on the sea, capable of carrying numerous troops.";
}
