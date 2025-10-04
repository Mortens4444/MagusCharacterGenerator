using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class AmuletOfLuck : MagicalObject
{
    public override string Name => "Amulet of Luck";

    public override Money Price => new(0, 2);
}
