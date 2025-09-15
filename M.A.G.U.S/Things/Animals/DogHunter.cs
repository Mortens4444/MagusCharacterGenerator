using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Animals;

public class DogHunter : Thing
{
	public override string Name => "Dog, hunter";

	public Money Price => new(0, 2, 0);
}
