using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class MithrilFullPlate : FullPlate
{
	public override string Name => "Mithril full plate";

	public override Money Price => new(20000, 0, 0);

	public override int ArmorCheckPenalty => -4;

	public override int ArmorClass => 8;

	public override double Weight => 10;

    public override string Description => "The rarest and most coveted full armour. Forged entirely from Mithril, it grants the highest defense without suffering the movement penalties of heavy steel, granting a champion near-invulnerability.";
}
