using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class WarmCoat : MagicalObject
{
    public override string Name => "Warm Coat";

    public override Money Price => new(3);

    public override int ManaPoints => 45;
}
