using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class MedallionOfBalance : MagicalObject
{
    public override string Name => "Medallion of Balance";

    public override Money Price => new(7);

    public override int ManaPoints => 73;
}
