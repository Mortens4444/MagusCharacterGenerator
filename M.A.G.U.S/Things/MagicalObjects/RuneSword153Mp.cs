using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class RuneSword153Mp : MagicalObject
{
    public override string Name => "Rune Sword (153 MP)";

    public override Money Price => new(5);

    public override int ManaPoints => 153;
}
