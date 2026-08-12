using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class MedallionOfSteelyWill : MagicalObject
{
    public override string Name => "Medallion of Steely Will";

    public override Money Price => new(7);

    public override int ManaPoints => 73;
}
