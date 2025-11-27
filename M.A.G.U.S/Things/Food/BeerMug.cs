using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Food;

public class BeerMug : Thing
{
    public override string Name => "Beer, mug";

    public override Money Price => new(0, 0, 1);

    public override string Description => "A sturdy clay or wooden tankard filled with common ale or brew. The daily drink of the common folk, safer than water and enough to stave off the chill and the pangs of hunger.";
}
