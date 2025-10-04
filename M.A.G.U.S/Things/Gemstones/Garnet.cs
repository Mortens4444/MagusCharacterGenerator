using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class Garnet : Gemstone
{
    public Garnet() : base("elementals (primordial fire)") { }

    public override Money Price => new Money(30);
}