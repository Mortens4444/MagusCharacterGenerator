using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class AmuletOfInvisibility : MagicalObject
{
    public override string Name => "Amulet of Invisibility";

    public override Money Price => new(0, 4);
}
