using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class CloakOfInvisibility : MagicalObject
{
    public override string Name => "Cloak of Invisibility";

    public override Money Price => new(4);

    public override int ManaPoints => 70;
}
