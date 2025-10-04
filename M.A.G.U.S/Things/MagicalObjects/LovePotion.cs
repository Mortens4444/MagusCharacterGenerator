using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class LovePotion : MagicalObject
{
    public override string Name => "Love Potion";

    public override Money Price => new(5);
}
