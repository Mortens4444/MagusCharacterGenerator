using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class RoseQuartz : Gemstone
{
    public RoseQuartz() : base("protection, wounds") { }

    public override string Name => "Rose Quartz";

    public override Money Price => new(6);
}