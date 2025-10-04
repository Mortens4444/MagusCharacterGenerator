using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class AmuletAgainstPoisons : MagicalObject
{
    public override string Name => "Amulet Against Poisons";

    public override Money Price => new(0, 2);
}
