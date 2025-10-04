using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class RuneSword : MagicalObject
{
    public override string Name => "Rune Sword";

    public override Money Price => new(5);
}
