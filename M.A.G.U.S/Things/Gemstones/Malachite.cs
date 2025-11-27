using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class Malachite : Gemstone
{
    public Malachite() : base("effects unknown") { }

    public override Money Price => new(1);
}