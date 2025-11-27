using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class SteelScaleArmor : Thing
{
	public override string Name => "Steel scale armor";

	public override Money Price => new(20, 0, 0);

	public int MovementInhibitingFactor => -2;

	public int DamageSusceptiveValue => 3;

	public override double Weight => 16;

    public override string Description => "Overlapping steel scales sewn onto a strong textile base. A dependable and widely used armor type that offers solid protection and is relatively easy to manufacture.";
}
