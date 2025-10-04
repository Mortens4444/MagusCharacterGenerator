using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class Hematite : Gemstone
{
    public Hematite() : base("combat, attack") { }

    public override Money Price => new Money(6);
}