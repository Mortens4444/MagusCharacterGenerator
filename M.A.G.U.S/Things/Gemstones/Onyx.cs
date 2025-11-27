using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class Onyx : Gemstone
{
    public Onyx() : base("discord, enmity") { }

    public override Money Price => new(5);
}