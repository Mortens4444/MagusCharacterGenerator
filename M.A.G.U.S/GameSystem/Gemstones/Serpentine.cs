using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.GameSystem.Gemstones;

public class Serpentine : Gemstone
{
    public Serpentine() : base("mental") { }

    public override Money Price => new Money(6);
}