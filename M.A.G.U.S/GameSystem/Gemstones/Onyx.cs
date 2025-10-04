using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.GameSystem.Gemstones;

public class Onyx : Gemstone
{
    public Onyx() : base("discord, enmity") { }

    public override Money Price => new Money(5);
}