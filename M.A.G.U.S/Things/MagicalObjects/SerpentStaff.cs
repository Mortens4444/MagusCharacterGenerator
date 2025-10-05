using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class SerpentStaff : MagicalObject
{
    public override string Name => "Serpent Staff";

    public override Money Price => new(6);

    public override int ManaPoints => 58;
}
