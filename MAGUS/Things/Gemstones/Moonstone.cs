using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Gemstones;

public class Moonstone : Gemstone
{
    public override Money Price => new(7);

    public override string Description => "shapeshifters, roaming beasts, night terrors";
}