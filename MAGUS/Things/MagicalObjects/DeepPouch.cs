using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class DeepPouch : MagicalObject
{
    public override string Name => "Deep Pouch";

    public override Money Price => new(4);

    public override int ManaPoints => 51;
}
