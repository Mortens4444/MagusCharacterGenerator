using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class HelmetOfTongues : MagicalObject
{
    public override string Name => "Helmet of Tongues";

    public override Money Price => new(5);

    public override int ManaPoints => 113;
}
