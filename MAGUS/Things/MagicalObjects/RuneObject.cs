using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public abstract class RuneObject : MagicalObject
{
    public Thing TargetItem { get; set; }

    public override Money Price => Money.DoubleIt(TargetItem?.Price ?? new(0));
}
