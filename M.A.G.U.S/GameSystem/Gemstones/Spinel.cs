using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.GameSystem.Gemstones;

public class Spinel : Gemstone
{
    public Spinel() : base("combat") { }

    public override Money Price => new Money(40);
}