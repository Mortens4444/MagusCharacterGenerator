using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class Moonstone : Gemstone
{
    public override Money Price => new(7);

    public override string Description => "shapeshifters, roaming beasts, night terrors";
}