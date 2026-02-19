using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class Chrysoprase : Gemstone
{
    public override Money Price => new(5);

    public override string Description => "invisibility, stealth";
}