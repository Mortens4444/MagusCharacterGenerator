using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Other;

public class Waterskin : Thing
{
	public override Money Price => new(0, 0, 3);

    public override string Description => "A leather pouch, usually made from the hide of a goat or pig, sealed to carry a ready supply of drinking water.";
}
