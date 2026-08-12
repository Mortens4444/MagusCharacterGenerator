using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Gemstones;

public class TigersEye : Gemstone
{
    public override string Name => "Tiger's Eye";

    public override Money Price => new(4);

    public override string Description => "theft, stealing, burglary";
}