using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class AbbitSteelFullPlate : FullPlate
{
	public override string Name => "Abbit-steel full plate";

	public override Money Price => new(500, 0, 0);

	public override int ArmorCheckPenalty => -6;

	public override int ArmorClass => 7;

	public override double Weight => 15;

    public override string Description => "The peak of personal defense. Full-body harness of polished Abbit-steel plates, articulated at every joint. Grants the wearer the fortitude of a walking fortress, though only the wealthiest or most storied champions possess it.";
}
