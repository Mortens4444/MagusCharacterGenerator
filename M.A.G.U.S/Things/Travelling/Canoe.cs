using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Travelling;

public class Canoe : Thing
{
	public override Money Price => new(7, 0, 0);

    public override string Description => "A light, narrow boat typically made of hollowed wood or stretched hide over a frame. It is swift and silent, favoured by hunters and scouts for navigating rivers.";
}
