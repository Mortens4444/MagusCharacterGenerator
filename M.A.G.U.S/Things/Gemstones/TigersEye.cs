using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class TigersEye : Gemstone
{
    public override string Name => "Tiger's Eye";

    public override Money Price => new(4);

    public override string Description => "theft, stealing, burglary";
}