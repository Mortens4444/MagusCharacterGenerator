using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Trappings;

public class HorseShoeAndShoeing : Thing
{
	public override string Name => "Horse shoe and shoeing";

	public Money Price => new(0, 1, 0);
}
