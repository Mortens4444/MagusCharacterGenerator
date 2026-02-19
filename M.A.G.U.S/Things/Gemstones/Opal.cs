using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class Opal : Gemstone
{
    public override Money Price => new(120);

    public override string Description => "magic of natural materials";
}