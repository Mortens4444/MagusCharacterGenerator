using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class RuneSword63Mp : MagicalObject
{
    public override string Name => "Rune Sword (63 MP)";

    public override Money Price => new(5);

    public override int ManaPoints => 63;
}
