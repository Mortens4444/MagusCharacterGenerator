using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Trappings;

public class HorseClothes : Thing
{
	public override string Name => "Horse clothes";

	public Money Price => new(0, 0, 4);
}
