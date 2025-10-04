using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class AmuletOfPower : MagicalObject
{
    public override string Name => "Amulet of Power";

    public override Money Price => new(0, 2);
}
