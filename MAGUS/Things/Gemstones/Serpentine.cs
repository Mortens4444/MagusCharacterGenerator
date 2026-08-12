using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Gemstones;

public class Serpentine : Gemstone
{
    public override Money Price => new(6);

    public override string Description => "mental";
}