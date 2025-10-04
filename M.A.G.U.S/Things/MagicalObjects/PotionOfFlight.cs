using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class PotionOfFlight : MagicalObject
{
    public override string Name => "Potion of Flight";

    public override Money Price => new(2);
}
