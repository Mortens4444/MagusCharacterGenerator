using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class BlackOpal : Gemstone
{
    public BlackOpal() : base("immunity against spells") { }

    public override string Name => "Black (Sonioni) Opal";

    public override Money Price => new Money(100);
}