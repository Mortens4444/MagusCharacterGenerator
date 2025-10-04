using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.GameSystem.Gemstones;

public class Jasper : Gemstone
{
    public Jasper() : base("poisons") { }

    public override Money Price => new Money(6);
}