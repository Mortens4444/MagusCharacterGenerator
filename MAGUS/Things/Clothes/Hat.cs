using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Clothes;

public class Hat : Thing
{
	public override Money Price => new(0, 0, 150);

    public override string Description => "A formal head covering with a distinct crown and brim. Its style often denotes the wearer's trade or rank, shading the face from the sun and rain.";
}
