using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class HelmetOfTongues : MagicalObject
{
    public override string Name => "Helmet of Tongues";

    public override Money Price => new(5);

    public override int ManaPoints => 113;
}
