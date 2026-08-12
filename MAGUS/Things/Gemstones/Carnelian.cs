using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Gemstones;

public class Carnelian : Gemstone
{
    public override Money Price => new(5);

    public override string Description => "evil beings, enemies, ill-wishers";
}