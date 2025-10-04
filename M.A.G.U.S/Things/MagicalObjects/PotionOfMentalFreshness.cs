using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class PotionOfMentalFreshness : MagicalObject
{
    public override string Name => "Potion of Mental Freshness";

    public override Money Price => new(2);
}
