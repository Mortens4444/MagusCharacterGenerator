using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Gemstones;

public class Hematite : Gemstone
{
    public override Money Price => new(6);

    public override string Description => "combat, attack";
}