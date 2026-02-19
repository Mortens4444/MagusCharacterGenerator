using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class Pearl : Gemstone
{
    public override Money Price => new(300);

    public override string Description => "healing";
}