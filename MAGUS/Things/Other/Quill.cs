using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Other;

public class Quill : Thing
{
	public override Money Price => new(0, 0, 20);

    public override string Description => "A feather sharpened to a fine point, used to dip into ink and write upon parchment or paper. The essential tool of the scholar.";
}
