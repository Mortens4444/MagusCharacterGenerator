using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class AbbitSteelLaminarArmor : LaminarArmor
{
	public override string Name => "Abbit-steel plate armor";

	public override Money Price => new(100, 0, 0);

	public override int ArmorCheckPenalty => -2;

	public override int ArmorClass => 4;

	public override double Weight => 7;

    public override string Description => "Protection formed from overlapping horizontal strips of Abbit-steel. This design affords excellent flexibility while ensuring that no single strip can be easily breached by a thrust.";
}
