using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class BottomlessJug : MagicalObject
{
    public override string Name => "Bottomless Jug";

    public override Money Price => new(0, 3);
}
