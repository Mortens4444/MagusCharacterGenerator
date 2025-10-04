using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.GameSystem.Gemstones;

public class Chrysoberyl : Gemstone
{
    public Chrysoberyl() : base("soul") { }

    public override Money Price => new Money(10);
}