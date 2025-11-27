using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class Alexandrite : Gemstone
{
    public Alexandrite() : base("demons") { }

    public override Money Price => new(20);
}