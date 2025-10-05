using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class ClimbingGloves : MagicalObject
{
    public override string Name => "Climbing Gloves";

    public override Money Price => new(3);

    public override int ManaPoints => 48;
}
