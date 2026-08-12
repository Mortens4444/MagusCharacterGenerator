using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class MedallionOfBalance : MagicalObject
{
    public override string Name => "Medallion of Balance";

    public override Money Price => new(7);

    public override int ManaPoints => 73;
}
