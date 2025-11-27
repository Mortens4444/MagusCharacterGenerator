using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class BarrelLarge : Thing
{
	public override string Name => "Barrel, large";

	public override Money Price => new(0, 4, 0);

    public override string Description => "A great, stout cask made of thick wooden staves bound with iron hoops. Used for the storage and transport of large quantities of wine, ale, or salted provisions.";
}
