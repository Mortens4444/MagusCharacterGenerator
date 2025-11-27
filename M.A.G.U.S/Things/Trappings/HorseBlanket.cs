using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Trappings;

public class HorseBlanket : Thing
{
	public override string Name => "Horse blanket";

	public override Money Price => new(0, 0, 4);

    public override string Description => "A heavy, woven cloth or piece of felt used to cover a horse's back and loins. It keeps the animal warm after exertion or during cold nights in the stable or camp.";
}
