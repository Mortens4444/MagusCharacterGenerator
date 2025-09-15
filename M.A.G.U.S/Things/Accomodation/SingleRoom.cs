using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Accomodation;

public class SingleRoom : Thing
{
	public override string Name => "Single room";

	public Money Price => new(0, 0, 7);
}
