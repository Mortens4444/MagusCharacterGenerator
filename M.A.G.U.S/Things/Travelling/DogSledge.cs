using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Travelling;

public class DogSledge : Thing
{
	public override string Name => "Dog sledge";

	public Money Price => new(0, 8, 0);
}
