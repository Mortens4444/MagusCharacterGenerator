using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class Coral : Gemstone
{
    public Coral() : base("seas, sailing, swimming") { }

    public override Money Price => new(13);
}