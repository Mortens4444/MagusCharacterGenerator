using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Travelling;

public class Sleigh : Thing
{
	public override Money Price => new(5, 0, 0);

    public override string Description => "A runner-equipped vehicle similar to a cart but lacking wheels, designed for being pulled over snow and ice by horses or other draught animals.";
}
