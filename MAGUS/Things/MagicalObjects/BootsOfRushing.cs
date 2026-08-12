using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class BootsOfRushing : MagicalObject
{
    public override string Name => "Boots of Rushing";

    public override Money Price => new(2);

    public override int ManaPoints => 53;
}
