using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class Emerald : Gemstone
{
    public Emerald() : base("general magical stone") { }

    public override Money Price => new Money(300);
}