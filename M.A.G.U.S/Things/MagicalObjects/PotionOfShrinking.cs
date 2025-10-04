using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class PotionOfShrinking : MagicalObject
{
    public override string Name => "Potion of Shrinking";

    public override Money Price => new(1);
}
