using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.GameSystem.Gemstones;

public class Jet : Gemstone
{
    public Jet() : base("elementals (primordial earth)") { }

    public override Money Price => new Money(12);
}