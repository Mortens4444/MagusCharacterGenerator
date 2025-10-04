using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class Diamond : Gemstone
{
    public Diamond() : base("undeads, poisons, illnesses") { }

    public override Money Price => new Money(500);
}