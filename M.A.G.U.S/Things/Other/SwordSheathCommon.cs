using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class SwordSheathCommon : Thing
{
	public override string Name => "Sword sheath, common";

	public override Money Price => new(0, 2, 0);

    public override string Description => "A simple leather scabbard for a sword. Provides necessary protection to the blade and keeps it safely secured to the belt.";
}
