using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Animals;

public class HorseTraveler : Thing
{
	public override string Name => "Horse, traveler";

	public override Money Price => new(1, 0, 0);
}
