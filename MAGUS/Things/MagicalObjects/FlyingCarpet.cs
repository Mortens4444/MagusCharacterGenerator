using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class FlyingCarpet : MagicalObject
{
    public override string Name => "Flying Carpet";

    public override Money Price => new(8);

    public override int ManaPoints => 98;
}
