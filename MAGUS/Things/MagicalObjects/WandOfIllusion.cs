using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class WandOfIllusion : MagicalObject
{
    public override string Name => "Wand of Illusion";

    public override Money Price => new(2);

    public override int ManaPoints => 113;
}
