using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class Nephrite : Gemstone
{
    public Nephrite() : base("elementals (elemental force)") { }

    public override Money Price => new Money(9);
}