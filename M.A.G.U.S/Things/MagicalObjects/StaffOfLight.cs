using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class StaffOfLight : MagicalObject
{
    public override string Name => "Staff of Light";

    public override Money Price => new(0, 8);

    public override int ManaPoints => 84;
}
