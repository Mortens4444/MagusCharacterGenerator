using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class Seeker : MagicalObject

{
    public override Money Price => new(3);

    public override int ManaPoints => 130;
}
