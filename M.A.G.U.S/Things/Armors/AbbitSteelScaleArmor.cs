using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class AbbitSteelScaleArmor : ScaleArmor
{
	public override string Name => "Abbit-steel scale armor";

	public override Money Price => new(50, 0, 0);

	public override int ArmorCheckPenalty => -1;

	public override int ArmorClass => 4;

	public override double Weight => 7;

    public override string Description => "A leather or fabric backing upon which are sewn numerous small, overlapping Abbit-steel scales. It grants good coverage, shrugging off glancing blows with the resilience of the rare metal.";
}
