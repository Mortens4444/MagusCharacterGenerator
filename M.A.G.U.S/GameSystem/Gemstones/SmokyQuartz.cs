using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.GameSystem.Gemstones;

public class SmokyQuartz : Gemstone
{
    public SmokyQuartz() : base("orientation, cardinal directions, term magic") { }

    public override string Name => "Smoky Quartz";

    public override Money Price => new Money(7);
}