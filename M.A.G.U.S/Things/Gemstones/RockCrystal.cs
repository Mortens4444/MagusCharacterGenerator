using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class RockCrystal : Gemstone
{
    public RockCrystal() : base("elementals (primordial air), ghosts") { }

    public override string Name => "Rose Crystal";

    public override Money Price => new(8);
}