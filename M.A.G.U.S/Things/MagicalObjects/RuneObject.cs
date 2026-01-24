using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public abstract class RuneObject : MagicalObject
{
    public Thing TargetItem { get; set; }

    public override Money Price => Money.DoubleIt(TargetItem?.Price ?? new(0));
}
