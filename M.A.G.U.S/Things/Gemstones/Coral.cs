using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class Coral : Gemstone
{
    public override Money Price => new(13);

    public override string Description => "seas, sailing, swimming";
}