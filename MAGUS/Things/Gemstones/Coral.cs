using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Gemstones;

public class Coral : Gemstone
{
    public override Money Price => new(13);

    public override string Description => "seas, sailing, swimming";
}