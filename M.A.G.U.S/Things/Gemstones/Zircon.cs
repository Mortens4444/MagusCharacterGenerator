using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class Zircon : Gemstone
{
    public Zircon() : base("time, time magic") { }

    public override Money Price => new Money(5);
}