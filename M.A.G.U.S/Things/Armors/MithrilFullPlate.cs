using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class MithrilFullPlate : Thing
{
	public override string Name => "Mithril full plate";

	public override Money Price => new(20000, 0, 0);

	public int MovementInhibitingFactor => -4;

	public int DamageSusceptiveValue => 8;

	public override double Weight => 10;

    public override string Description => "The rarest and most coveted full armour. Forged entirely from Mithril, it grants the highest defense without suffering the movement penalties of heavy steel, granting a champion near-invulnerability.";
}
