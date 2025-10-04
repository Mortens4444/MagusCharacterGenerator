using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class PotionOfPower : MagicalObject
{
    public override string Name => "Potion of Power";

    public override Money Price => new(1);
}
