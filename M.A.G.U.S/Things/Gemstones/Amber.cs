using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class Amber : Gemstone
{
    public override Money Price => new(20);

    public override string Description => "illnesses";
}