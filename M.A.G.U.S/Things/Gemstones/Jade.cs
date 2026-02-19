using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class Jade : Gemstone
{
    public override Money Price => new(15);

    public override string Description => "music, singing, dance, sounds";
}