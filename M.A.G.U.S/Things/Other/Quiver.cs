using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class Quiver : Thing
{
	public override Money Price => new(0, 0, 150);

    public override string Description => "A leather container worn on the back or hip, designed to securely hold a supply of arrows or bolts for bow or crossbow.";
}
