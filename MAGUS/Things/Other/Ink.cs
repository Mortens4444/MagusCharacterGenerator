using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Other;

public class Ink : Thing
{
	public override Money Price => new(0, 0, 20);

    public override string Description => "A vial of dark, flowing liquid made from gall nuts or soot. Essential for the scholar, scribe, or merchant for writing and record-keeping.";
}
