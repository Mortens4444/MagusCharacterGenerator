using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class BottomlessJug : MagicalObject
{
    public override string Name => "Bottomless Jug";

    public override Money Price => new(0, 3);

    public override int ManaPoints => 83;
}
