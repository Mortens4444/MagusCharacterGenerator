using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Animals;

public class DogSledge : Thing
{
	public override string Name => "Dog, sled";

	public override Money Price => new(0, 0, 120);
}
