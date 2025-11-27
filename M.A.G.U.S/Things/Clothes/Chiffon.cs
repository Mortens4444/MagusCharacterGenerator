using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Clothes;

public class Chiffon : Thing
{
	public override Money Price => new(0, 3, 0);

    public override string Name => "Robe";

    public override string Description => "A sheer, lightweight fabric favoured by noble women for veils, scarves, or as a delicate trim on gowns. It offers a whisper of modesty without concealing beauty.";
}
