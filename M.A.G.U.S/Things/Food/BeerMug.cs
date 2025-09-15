using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Food;

public class BeerMug : Thing
{
    public override string Name => "Beer, mug";

    public Money Price => new(0, 0, 1);
}
