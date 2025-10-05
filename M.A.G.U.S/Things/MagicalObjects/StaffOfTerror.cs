using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class StaffOfTerror : MagicalObject
{
    public override string Name => "Staff of Terror";

    public override Money Price => new(4);

    public override int ManaPoints => 73;
}
