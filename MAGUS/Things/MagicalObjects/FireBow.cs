using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class FireBow : MagicalObject
{
    public override string Name => "Fire Bow";

    public override Money Price => new(8);

    public override int ManaPoints => 53;
}
