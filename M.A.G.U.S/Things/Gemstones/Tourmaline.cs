using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class Tourmaline : Gemstone
{
    public Tourmaline() : base("combat, protection") { }

    public override Money Price => new(10);
}