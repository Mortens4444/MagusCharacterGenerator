using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class PotionOfInvisibility : MagicalObject
{
    public override string Name => "Potion of Invisibility";

    public override Money Price => new(3);
}
