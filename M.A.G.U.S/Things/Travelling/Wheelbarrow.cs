using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Travelling;

public class Wheelbarrow : Thing
{
	public override Money Price => new(0, 0, 50);

    public override string Description => "A simple, one-wheeled wooden cart with handles, used by labourers to push heavy loads of soil, stone, or refuse over short distances.";
}
