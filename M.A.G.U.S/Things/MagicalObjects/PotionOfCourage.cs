using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class PotionOfCourage : MagicalObject
{
    public override string Name => "Potion of Courage";

    public override Money Price => new(5);
}
