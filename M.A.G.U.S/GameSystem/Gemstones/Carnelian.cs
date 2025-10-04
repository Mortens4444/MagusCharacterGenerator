using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.GameSystem.Gemstones;

public class Carnelian : Gemstone
{
    public Carnelian() : base("evil beings, enemies, ill-wishers") { }

    public override Money Price => new Money(5);
}