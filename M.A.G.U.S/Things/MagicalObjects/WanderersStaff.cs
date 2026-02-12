using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class WanderersStaff : MagicalObject
{
    public override string Name => "Wanderer's Staff";

    public override Money Price => new(0, 3);

    public override int ManaPoints => 63;
}
