using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class Spinel : Gemstone
{
    public override Money Price => new(40);

    public override string Description => "combat";
}