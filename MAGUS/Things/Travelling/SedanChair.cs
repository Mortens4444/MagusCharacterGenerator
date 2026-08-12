using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Travelling;

public class SedanChair : Thing
{
	public override string Name => "Sedan chair";

	public override Money Price => new(10, 0, 0);

    public override string Description => "A small, enclosed passenger compartment carried upon poles by two or four sturdy bearers. Reserved for the very rich, allowing them to travel through city streets without touching the dirty ground.";
}
