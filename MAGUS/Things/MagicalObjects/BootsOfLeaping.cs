using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class BootsOfLeaping : MagicalObject
{
    public override string Name => "Boots of Leaping";

    public override Money Price => new(2);

    public override int ManaPoints => 43;
}
