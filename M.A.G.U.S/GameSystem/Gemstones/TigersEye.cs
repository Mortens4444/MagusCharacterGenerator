using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.GameSystem.Gemstones;

public class TigersEye : Gemstone
{
    public TigersEye() : base("theft, stealing, burglary") { }

    public override string Name => "Tiger's Eye";

    public override Money Price => new Money(4);
}