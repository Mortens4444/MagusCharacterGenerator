using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Clothes;

public class Trousers : Thing
{
	public override Money Price => new(0, 0, 3);

    public override string Name => "Trousers (peasant)";
}
