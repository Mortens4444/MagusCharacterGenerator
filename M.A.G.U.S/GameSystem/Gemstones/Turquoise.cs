using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.GameSystem.Gemstones;

public class Turquoise : Gemstone
{
    public Turquoise() : base("horses, riding") { }

    public override Money Price => new Money(2);
}