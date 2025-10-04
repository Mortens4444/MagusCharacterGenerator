using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.GameSystem.Gemstones;

public class Moonstone : Gemstone
{
    public Moonstone() : base("shapeshifters, roaming beasts, night terrors") { }

    public override Money Price => new Money(7);
}