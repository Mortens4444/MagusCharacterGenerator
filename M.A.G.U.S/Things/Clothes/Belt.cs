using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Clothes;

public class Belt : Thing
{
    public override string Name => "Belt";

    public override Money Price => new(0, 0, 20);
}
