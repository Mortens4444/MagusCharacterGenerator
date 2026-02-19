using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class Carnelian : Gemstone
{
    public override Money Price => new(5);

    public override string Description => "evil beings, enemies, ill-wishers";
}