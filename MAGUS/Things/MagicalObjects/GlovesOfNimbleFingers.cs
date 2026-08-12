using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class GlovesOfNimbleFingers : MagicalObject
{
    public override string Name => "Gloves of Nimble Fingers";

    public override Money Price => new(2);

    public override int ManaPoints => 83;
}
