using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class MagicScroll : MagicalObject
{
    public override string Name => "Magic Scroll";

    public override Money Price => new(0, 2);
}
