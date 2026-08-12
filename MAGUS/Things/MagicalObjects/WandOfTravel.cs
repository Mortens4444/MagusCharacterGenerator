using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class WandOfTravel : MagicalObject
{
    public override string Name => "Wand of Travel";

    public override Money Price => new(0, 2);

    public override int ManaPoints => 103;
}
