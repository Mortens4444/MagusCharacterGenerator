using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class FlyingCarpet : MagicalObject
{
    public override string Name => "Flying Carpet";

    public override Money Price => new(8);

    public override int ManaPoints => 98;
}
