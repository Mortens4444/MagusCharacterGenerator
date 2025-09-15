using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Animals;

public class HorseYoke : Thing
{
	public override string Name => "Horse, yoke";

	public Money Price => new(0, 8, 0);
}
