using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Clothes;

public class Hood : Thing
{
	public override Money Price => new(0, 0, 8);

    public override string Description => "A simple head covering often attached to a cloak or tunic. It draws tightly about the face, concealing the wearer's identity and protecting from foul weather.";
}
