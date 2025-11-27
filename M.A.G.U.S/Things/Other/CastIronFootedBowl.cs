using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class CastIronFootedBowl : Thing
{
	public override string Name => "Iron pot";

	public override Money Price => new(0, 0, 10);

    public override string Description => "A heavy, three-legged cooking pot made of cast iron. It is designed to stand directly over a fire for preparing stews and hot meals.";
}
