using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class BannerOfHeroes : MagicalObject
{
    public override string Name => "Banner of Heroes";

    public override Money Price => new(10);
}
