using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Gemstones;

public class LapisLazuli : Gemstone
{
    public override string Name => "Lapis Lazuli";

    public override Money Price => new(2);

    public override string Description => "psyche, mind";
}