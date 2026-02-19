using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class Zircon : Gemstone
{
    public override Money Price => new(5);

    public override string Description => "time, time magic";
}